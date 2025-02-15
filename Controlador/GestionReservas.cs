using System;
using System.Linq;
using System.Windows.Forms;
using GenteFit.Modelos;
using System.Data.Entity;

namespace GenteFit.Controlador
{
    public class GestionReservas
    {
        public void ReservarActividad(int clienteId, int actividadId)
        {
            using (var context = new GenteFitCristinaEntities1())
            {
                var actividad = context.Actividad
                    .Include(a => a.Reserva)
                    .Include(a => a.ListaEspera)
                    .FirstOrDefault(a => a.ActividadID == actividadId);

                var cliente = context.Cliente.Find(clienteId);

                if (actividad == null || cliente == null)
                {
                    MessageBox.Show("Actividad o cliente no encontrado.");
                    return;
                }

                // Calcula plazas disponibles
                int plazasDisponibles = actividad.PlazasTotales - actividad.Reserva.Count;

                if (plazasDisponibles > 0)
                {
                    // Verifica si el cliente ya tiene una reserva para esta actividad
                    if (context.Reserva.Any(r => r.ClienteID == clienteId && r.ActividadID == actividadId))
                    {
                        MessageBox.Show("Ya tienes una reserva para esta actividad.");
                        return;
                    }

                    // Crear y guardar la reserva
                    var reserva = new Reserva
                    {
                        FechaReserva = DateTime.Now,
                        EstadoReserva = "Confirmada",
                        ClienteID = clienteId,
                        ActividadID = actividadId
                    };
                    context.Reserva.Add(reserva);
                    context.SaveChanges();
                    MessageBox.Show("Reserva confirmada.");
                }
                else
                {
                    // Verifica si el cliente ya esta en  lista de espera
                    if (context.ListaEspera.Any(le => le.ClienteID == clienteId && le.ActividadID == actividadId))
                    {
                        MessageBox.Show("Ya estás en la lista de espera para esta actividad.");
                        return;
                    }

                    // Añadir a la lista de espera
                    int posicion = actividad.ListaEspera.Count + 1;
                    var listaEspera = new ListaEspera
                    {
                        Posicion = posicion,
                        ClienteID = clienteId,
                        ActividadID = actividadId
                    };
                    context.ListaEspera.Add(listaEspera);
                    context.SaveChanges();
                    MessageBox.Show($"Actividad llena. Añadido a la lista de espera en posición {posicion}.");
                }
            }
        }

        public void CancelarReserva(int reservaId)
        {
            using (var context = new GenteFitCristinaEntities1())
            {
                var reserva = context.Reserva.Find(reservaId);
                if (reserva != null)
                {
                    int actividadId = reserva.ActividadID.Value;
                    context.Reserva.Remove(reserva);
                    context.SaveChanges();

                    // Verifica si hay clientes en la lista de espera
                    var listaEspera = context.ListaEspera
                        .Where(le => le.ActividadID == actividadId)
                        .OrderBy(le => le.Posicion)
                        .FirstOrDefault();

                    if (listaEspera != null)
                    {
                        // Crear nueva reserva para el primer cliente en lista de espera
                        var nuevaReserva = new Reserva
                        {
                            FechaReserva = DateTime.Now,
                            EstadoReserva = "Confirmada",
                            ClienteID = listaEspera.ClienteID,
                            ActividadID = actividadId
                        };
                        context.Reserva.Add(nuevaReserva);
                        context.ListaEspera.Remove(listaEspera);

                        // Actualizar posiciones en la lista de espera
                        var listaEsperaActualizada = context.ListaEspera
                            .Where(le => le.ActividadID == actividadId)
                            .OrderBy(le => le.Posicion)
                            .ToList();

                        int posicion = 1;
                        foreach (var item in listaEsperaActualizada)
                        {
                            item.Posicion = posicion++;
                        }

                        context.SaveChanges();
                        MessageBox.Show("Reserva cancelada y lista de espera actualizada.");
                    }
                    else
                    {
                        MessageBox.Show("Reserva cancelada. No hay clientes en lista de espera.");
                    }
                }
                else
                {
                    MessageBox.Show("Reserva no encontrada.");
                }
            }
        }
    }
}
