using ServiceOrderManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ServiceOrderManager.Models.Enums;


namespace ServiceOrderManager.Data
{
    public class SeedingService
    {
        private ServiceOrderManagerContext _context;

        public SeedingService(ServiceOrderManagerContext context)
        {
            _context = context;
        }

        public void Seed()
        {
            if (_context.Equipment.Any() || _context.OrderService.Any())
            {
                return; //Db has been seeded
            }

            Equipment eq1 = new Equipment(1, "GXA0928", 654321, "CAMINHÃO CAVALO, Modelo Axor2041 Ano 2015 Fabricação 2014, ENTREGA DE MINÉRIOS");
            Equipment eq2 = new Equipment(2, "SERRA:5A8S", 4, "SETOR DE CORTE DE MADEIRA");
            Equipment eq3 = new Equipment(3, "LAVADOURA", 1, "SETOR LAVANDERIA");
            Equipment eq4 = new Equipment(4, "BRITADEIRA", 3, "SETOR CONSTRUÇÃO");
            Equipment eq5 = new Equipment(5, "HBN7884", 25341, "CAMINHÃO TRUCK, Modelo ATEGO 2425 Ano 2010 Fabricação 2009, RECOLHE LIXO HOSPITALAR");
            Equipment eq6 = new Equipment(6, "GXA0863", 200654, "CAMINHÃO CAVALO, Modelo Axor2041 Ano 2018 Fabricação 2017, ENTREGA DE MINÉRIOS");
            Equipment eq7 = new Equipment(7, "COMPRESSOR DE AR", 7, "Modelo ASP138, SETOR LAVADOR/BORRACHARIA");
            Equipment eq8 = new Equipment(8, "GXA0928", 654321, "CAMINHÃO CAVALO, Modelo Axor2041 Ano 2015 Fabricação 2014, ENTREGA DE MINÉRIOS");
            Equipment eq9 = new Equipment(9, "SERRA:5A8S", 4, "SETOR DE CORTE DE MADEIRA");
            Equipment eq10 = new Equipment(10, "LAVADOURA", 1, "SETOR LAVANDERIA");
            Equipment eq11 = new Equipment(11, "BRITADEIRA", 3, "SETOR CONSTRUÇÃO");
            Equipment eq12 = new Equipment(12, "HBN7884", 25341, "CAMINHÃO TRUCK, Modelo ATEGO 2425 Ano 2010 Fabricação 2009, RECOLHE LIXO HOSPITALAR");
            Equipment eq13 = new Equipment(13, "GXA0863", 200654, "CAMINHÃO CAVALO, Modelo Axor2041 Ano 2018 Fabricação 2017, ENTREGA DE MINÉRIOS");
            Equipment eq14 = new Equipment(14, "COMPRESSOR DE AR", 7, "Modelo ASP138, SETOR LAVADOR/BORRACHARIA");


            OrderService os1 = new OrderService(1, "Trocar Oleo de caixa e diferencial, regular freios", new DateTime(2021, 6, 30), eq1, 1200.0, Status.Analysis, Priority.Urgent);
            OrderService os2 = new OrderService(2, "Lâmina está cega", new DateTime(2021, 6, 25), eq2, 500.0, Status.Making, Priority.Median);
            OrderService os3 = new OrderService(3, "Técnico está indo no local verificar", new DateTime(2021, 6, 24), eq3, 50.0, Status.Making, Priority.Median);
            OrderService os4 = new OrderService(4, "Perdeu a força, não está quebrando as pedras", new DateTime(2021, 6, 25), eq4, 200.0, Status.Waiting, Priority.Good);
            OrderService os5 = new OrderService(5, "Motor de arranque com problemas, Eletricista no Local", new DateTime(2021, 6, 24), eq5, 0.0, Status.Making, Priority.Urgent);
            OrderService os6 = new OrderService(6, "Veículo Colidiu com outro", new DateTime(2021, 8, 30), eq6, 70000.0, Status.Analysis, Priority.Good);
            OrderService os7 = new OrderService(7, "Biela danificada", new DateTime(2021, 6, 25), eq7, 265.0, Status.Making, Priority.Urgent);

            OrderService os8 = new OrderService(8, "Troca de 4 pneus tração", new DateTime(2021, 6, 23), eq1, 12000.0, Status.Completed, Priority.Good);
            os8.InternalControlOS = 640987;
            os8.Finish = new DateTime(2021, 6, 22);
            OrderService os9 = new OrderService(9, "Troca da tomada de força", new DateTime(2021, 6, 24), eq2, 50.0, Status.Completed, Priority.Median);
            os9.InternalControlOS = 3;
            os9.Finish = new DateTime(2021, 6, 24);
            OrderService os10 = new OrderService(10, "Ajuste na placa controladora", new DateTime(2021, 6, 24), eq3, 150.0, Status.Completed, Priority.Urgent);
            os10.InternalControlOS = 2;
            os10.Finish = new DateTime(2021, 6, 24);
            OrderService os11 = new OrderService(11, "Troca da ponteira trincada", new DateTime(2021, 6, 24), eq4, 200.0, Status.Completed, Priority.Urgent);
            os11.InternalControlOS = 3;
            os11.Finish = new DateTime(2021, 6, 23);
            OrderService os12 = new OrderService(12, "Troca dos Farois", new DateTime(2021, 6, 25), eq5, 864.69, Status.Completed, Priority.Median);
            os12.InternalControlOS = 23879;
            os12.Finish = new DateTime(2021, 6, 24);
            OrderService os13 = new OrderService(13, "Verificação dos embuxamentos de cabine", new DateTime(2021, 6, 22), eq6, 420.0, Status.Completed, Priority.Urgent);
            os13.InternalControlOS = 199878;
            os13.Finish = new DateTime(2021, 6, 22);
            OrderService os14 = new OrderService(14, "Manutenção preventiva feita pelo técnico", new DateTime(2021, 6, 30), eq7, 98.90, Status.Completed, Priority.Good);
            os14.InternalControlOS = 6;
            os14.Finish = new DateTime(2021, 6, 29);


            _context.Equipment.AddRange(eq1, eq2, eq3, eq4, eq5, eq6, eq7, eq8, eq9, eq10, eq11, eq12, eq13, eq14);

            _context.OrderService.AddRange(os1, os2, os3, os4, os5, os6, os7, os8, os9, os10, os11, os12, os13, os14);

            _context.SaveChanges();
        }

        
    }
}
