using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Prueba_Tecnica_NetForemost.Models;

namespace Prueba_Tecnica_NetForemost.Controllers
{
    public class AsignacionSaldoGestorController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AsignacionSaldoGestorController(ApplicationDbContext context)
        {
            _context = context;
        }


        public IActionResult Index()
        {
            return View(new List<AsignacionSaldosGestores>());
        }

        [HttpPost]
        public async Task <IActionResult> Ejecutar()
        {
            try
            {
                var asignaciones = await _context.AsignacionSaldosGestores.FromSqlRaw(@"
                                                                               EXEC Asignar_Saldos_a_Gestores;

                                                                               SELECT GS.id_gestor AS GestorID,
                                                                               G.nombre+' '+ ISNULL(G.apellido,'') AS GestorNombre,
                                                                               COUNT(1) AS NumSaldos, SUM(S.monto) AS Monto
                                                                               FROM Gestor_Saldo AS GS
                                                                               JOIN Saldo AS S ON GS.id_saldo = S.id_saldo
                                                                               JOIN Gestor AS G ON GS.id_gestor = G.id_gestor
                                                                               GROUP BY GS.id_gestor, G.nombre+' '+ ISNULL(G.apellido,'')
                                                                               ORDER BY GS.id_gestor").ToListAsync();
                return View("Index", asignaciones);
            }
            catch
            {
                return RedirectToAction("Index");
            }
        }
    }
}
