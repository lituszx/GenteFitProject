import os
import sys
import xmlrpc.client
import xml.etree.ElementTree as ET
import traceback

# He puesto muchos prints para comprobar que cada paso se lleva a cabo ok.

def authenticate(url, db, username, password):
    print("Intentando autenticar en Odoo...")
    try:
        common = xmlrpc.client.ServerProxy(f'{url}/xmlrpc/2/common')
        uid = common.authenticate(db, username, password, {})
        if uid:
            print("¡Autenticacion correcta!")
        else:
            print("Autenticacion fallida - Credenciales incorrectas o base de datos no encontrada.")
            raise ValueError("La autenticacion ha fallado.")
        return uid
    except Exception as e:
        print("Error con la autenticacion con Odoo:")
        print(e)
        traceback.print_exc()
        raise

def validate_with_xsd(xml_path, xsd_path):
    try:
        # Parseamos el XSD
        try:
            ET.parse(xsd_path)
        except ET.ParseError as pe:
            print("Error de validacion XSD: El XSD no es valido.")
            print(pe)
            raise

        # Ahora parseamos el XML
        try:
            ET.parse(xml_path)
        except ET.ParseError as pe:
            print("Error de validacion XSD: El XML no cumple con el esquema especificado, no se pudo parsear.")
            print(pe)
            raise

        # Si llegamos aqui, asumimos validacion exitosa
        print("Validacion XSD completada. El XML es valido.")
    except Exception as e:
        print("Error de validacion XSD: El XML no cumple con el esquema especificado.")
        print(e)
        raise

def load_xml(filepath):
    print(f"Intentando cargar el archivo XML: {filepath}")
    try:
        tree = ET.parse(filepath)
        root = tree.getroot()
        print("XML parseado correctamente.")
        return root
    except FileNotFoundError:
        print(f"Archivo no encontrado: {filepath}")
        raise
    except ET.ParseError as pe:
        print(f"Error al parsear el XML en {filepath}: {pe}")
        traceback.print_exc()
        raise

def manage_odoo_record(db, uid, password, models, model, data, search_field, search_value):
    try:
        print(f"Buscando registro en {model} con {search_field}: {search_value}")
        existing_ids = models.execute_kw(db, uid, password, model, 'search', [[[search_field, '=', search_value]]])
        if not existing_ids:
            print("No existe, intentando crear el registro...")
            models.execute_kw(db, uid, password, model, 'create', [data])
            print("Registro creado con éxito")
        else:
            print(f"El registro con {search_field}={search_value} ya existe, no añadimos uno nuevo.")
    except xmlrpc.client.Fault as fault:
        print("Error en la llamada XML-RPC a Odoo:")
        print(f"Falla: {fault.faultString}")
        traceback.print_exc()
        raise

# definimos una funcion por tabla
def process_usuarios(root, db, uid, password, models):
    usuarios = root.findall('./Clientes/Usuarios/Usuario')

    for usuario in usuarios:
        nombre = usuario.find('NombreUsuario').text if usuario.find('NombreUsuario') is not None else None
        contrasena = usuario.find('Contraseña').text if usuario.find('Contraseña') is not None else None
        rol = usuario.find('Rol').text if usuario.find('Rol') is not None else None

        if not nombre or not rol:
            print(f"Usuario con datos incompletos. Nombre: {nombre}, Rol: {rol}. Se omite.")
            continue

        data = {
            'x_studio_user': nombre,
            'x_studio_password': contrasena,
            'x_studio_role': rol,
            'x_name': nombre
        }

        manage_odoo_record(db, uid, password, models, 'x_usuarios', data, 'x_studio_user', nombre)

def process_monitores(root, db, uid, password, models):
    monitores = root.findall('./Clientes/Monitores/Monitor')

    for monitor in monitores:
        nombre = monitor.find('Nombre').text if monitor.find('Nombre') is not None else None
        apellidos = monitor.find('Apellidos').text if monitor.find('Apellidos') is not None else None
        telefono = monitor.find('Telefono').text if monitor.find('Telefono') is not None else None
        correo = monitor.find('Correo').text if monitor.find('Correo') is not None else None
        usuario_id = monitor.find('UsuarioID').text if monitor.find('UsuarioID') is not None else None

        if not nombre or not apellidos or not correo:
            print(f"Monitor con datos incompletos. Nombre: {nombre}, Apellidos: {apellidos}, Correo: {correo}. Se omite.")
            continue

        data = {
            'x_name': nombre,
            'x_studio_nombre': nombre,
            'x_studio_apellidos': apellidos,
            'x_studio_telefono': telefono,
            'x_studio_correo': correo,
            'x_studio_usuario_id': usuario_id
        }

        manage_odoo_record(db, uid, password, models, 'x_monitores', data, 'x_studio_correo', correo)

def process_clientes(root, db, uid, password, models):
    clientes = root.findall('./Clientes/Cliente')

    for cliente in clientes:
        nombre = cliente.find('Nombre').text if cliente.find('Nombre') is not None else None
        apellidos = cliente.find('Apellidos').text if cliente.find('Apellidos') is not None else None
        correo = cliente.find('Correo').text if cliente.find('Correo') is not None else None
        telefono = cliente.find('Telefono').text if cliente.find('Telefono') is not None else None
        fecha_nacimiento = cliente.find('FechaNacimiento').text if cliente.find('FechaNacimiento') is not None else None
        direccion = cliente.find('Direccion').text if cliente.find('Direccion') is not None else None
        usuario_id = cliente.find('UsuarioID').text if cliente.find('UsuarioID') is not None else None

        if not nombre or not apellidos or not correo:
            print(f"Cliente con datos incompletos. Nombre: {nombre}, Apellidos: {apellidos}, Correo: {correo}. Se omite.")
            continue

        data = {
            'x_name': nombre,
            'x_studio_nombre': nombre,
            'x_studio_apellidos': apellidos,
            'x_studio_correo': correo,
            'x_studio_telefono': telefono,
            'x_studio_fecha_nacimiento': fecha_nacimiento,
            'x_studio_direccion': direccion,
            'x_studio_usuario_id': usuario_id
        }

        manage_odoo_record(db, uid, password, models, 'x_clientes', data, 'x_studio_correo', correo)

def process_salas(root, db, uid, password, models):
    salas = root.findall('./Salas/Sala')

    for sala in salas:
        nombre = sala.find('Nombre').text if sala.find('Nombre') is not None else None
        capacidad = sala.find('Capacidad').text if sala.find('Capacidad') is not None else None

        if not nombre or not capacidad:
            print(f"Sala con datos incompletos. Nombre: {nombre}, Capacidad: {capacidad}. Se omite.")
            continue

        data = {
            'x_name': nombre,
            'x_studio_nombre': nombre,
            'x_studio_capacidad': capacidad
        }

        manage_odoo_record(db, uid, password, models, 'x_salas', data, 'x_studio_nombre', nombre)

def process_actividades(root, db, uid, password, models):
    actividades = root.findall('./Actividades/Actividad')

    for actividad in actividades:
        nombre = actividad.find('Nombre').text if actividad.find('Nombre') is not None else None
        descripcion = actividad.find('Descripcion').text if actividad.find('Descripcion') is not None else None
        intensidad = actividad.find('Intensidad').text if actividad.find('Intensidad') is not None else None
        plazas_totales = actividad.find('PlazasTotales').text if actividad.find('PlazasTotales') is not None else None
        horario = actividad.find('Horario').text if actividad.find('Horario') is not None else None
        sala_id = actividad.find('SalaID').text if actividad.find('SalaID') is not None else None
        monitor_id = actividad.find('MonitorID').text if actividad.find('MonitorID') is not None else None

        if not nombre or not plazas_totales or not horario:
            print(f"Actividad con datos incompletos. Nombre: {nombre}, PlazasTotales: {plazas_totales}, Horario: {horario}. Se omite.")
            continue

        data = {
            'x_name': nombre,
            'x_studio_nombre': nombre,
            'x_studio_descripcion': descripcion,
            'x_studio_intensidad': intensidad,
            'x_studio_plazas_totales': plazas_totales,
            'x_studio_horario': horario,
            'x_studio_sala_id': sala_id,
            'x_studio_monitor_id': monitor_id
        }

        manage_odoo_record(db, uid, password, models, 'x_actividades', data, 'x_studio_nombre', nombre)

def process_reservas(root, db, uid, password, models):
    reservas = root.findall('./Reservas/Reserva')

    for reserva in reservas:
        fecha_reserva = reserva.find('FechaReserva').text if reserva.find('FechaReserva') is not None else None
        estado_reserva = reserva.find('EstadoReserva').text if reserva.find('EstadoReserva') is not None else None
        cliente_id = reserva.find('ClienteID').text if reserva.find('ClienteID') is not None else None
        actividad_id = reserva.find('ActividadID').text if reserva.find('ActividadID') is not None else None

        if not fecha_reserva or not estado_reserva:
            print(f"Reserva con datos incompletos. FechaReserva: {fecha_reserva}, EstadoReserva: {estado_reserva}. Se omite.")
            continue

        data = {
            'x_name': 'Reserva',
            'x_studio_fecha_reserva': fecha_reserva,
            'x_studio_estado_reserva': estado_reserva,
            'x_studio_cliente_id': cliente_id,
            'x_studio_actividad_id': actividad_id
        }

        manage_odoo_record(db, uid, password, models, 'x_reservas', data, 'x_studio_fecha_reserva', fecha_reserva)

if __name__ == "__main__":
    print("Empieza la ejecucion del script")

    if len(sys.argv) < 3:
        print("Usamos: python importar_odoo.py en <ruta_xml> <tabla_seleccionada>")
        sys.exit(1)

    xml_path = sys.argv[1]
    tabla_seleccionada = sys.argv[2]

    # Configuramos la conexion
    url = 'https://gentefit4.odoo.com'
    db = 'gentefit4'
    username = 'cdiazmoli@uoc.edu'
    password = '3XtY?QyC7_+m-Np'

    # Usamos ruta absoluta, hay que cambiar si se ejecuta desde otra maquina
    XSD_PATH = r"C:\Users\MarinaPC\Downloads\GENTEFIT_YAFURRULA\ProyectoGenteFit\schemas\GenteFitData.xsd"

    try:
        validate_with_xsd(xml_path, XSD_PATH)
        uid = authenticate(url, db, username, password)
        print("Obteniendo acceso a la API de modelos...")
        models = xmlrpc.client.ServerProxy(f'{url}/xmlrpc/2/object')

        root = load_xml(xml_path)

        # dependiendo de la eleccion del user, se pasa una funcion u otra
        if tabla_seleccionada == "Usuario":
            process_usuarios(root, db, uid, password, models)
        elif tabla_seleccionada == "Monitor":
            process_monitores(root, db, uid, password, models)
        elif tabla_seleccionada == "Cliente":
            process_clientes(root, db, uid, password, models)
        elif tabla_seleccionada == "Sala":
            process_salas(root, db, uid, password, models)
        elif tabla_seleccionada == "Actividad":
            process_actividades(root, db, uid, password, models)
        elif tabla_seleccionada == "Reserva":
            process_reservas(root, db, uid, password, models)
        else:
            print(f"No hay un procesamiento definido para la tabla: {tabla_seleccionada}")

        print("Procesamiento completado sin errores.")
    except Exception as e:
        print("No se ha podido ejecutar el script :( Arroja el error :")
        print(e)
        traceback.print_exc()
