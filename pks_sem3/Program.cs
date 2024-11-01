using pks_sem3;

static void Main()
{
    List<Client> Clients = [];
    for (int i = 0; i < 1000; i++)
    {
        Clients.Add(Client.GenerateClients());
    }

    List<ReservationWindow> Reservations = [];
    List<Table> Tables = [];
    Console.WriteLine("Choose option:");
    Console.WriteLine("1. Add tables");
    Console.WriteLine("2. show table by ID");
    Console.WriteLine("3. Add reservation");
    Console.WriteLine("4. Filter Reservations by client name");
    Console.WriteLine("5. Filter Reservations by client phone number");
    Console.WriteLine("6. Show all reservations");
    Console.WriteLine("7. Filter tables by location/seats/time");
    Console.WriteLine("8. Edit unresevered table");
    Console.WriteLine("9. Exit");
    while (true)
    {
        string option = Console.ReadLine();
        switch (option)
        {
            case "1":
                Console.WriteLine("Enter number of tables:");
                int tables = int.Parse(Console.ReadLine());
                for (int i = 0; i < tables; i++)
                {
                    Tables.Add(Table.GenerateTable());
                }

                break;
            case "2":
                Console.WriteLine("Enter Table ID:");
                int tableId = int.Parse(Console.ReadLine());
                var table = Tables.Find(x => x.GetTableId() == tableId);
                if (table != null)
                {
                    Console.WriteLine(table.GetTableData());
                    Reservations.Where(x => x.GetTable() == table).ToList()
                        .ForEach(x => Console.WriteLine(x.GetReservationData()));
                }
                else
                {
                    Console.WriteLine("Table with provided ID not found");
                }

                break;
            case "3":
                Console.WriteLine("Enter reservation count:");
                int reservations = int.Parse(Console.ReadLine());
                for (int i = 0; i < reservations; i++)
                {
                    Random random = new Random();
                    int tableIndex = random.Next(0, Tables.Count);
                    int slotIndex = random.Next(8, 22);
                    int clientIndex = random.Next(0, Clients.Count);
                    Reservations =
                        ReservationWindow.AddReservationWindow(Reservations, Clients[clientIndex], Tables[tableIndex],
                            "asdjaskd", slotIndex);
                }

                break;
            case "6":
                foreach (var reservation in Reservations)
                {
                    Console.WriteLine("Table: " + reservation.GetTable().GetTableId() + ": " +
                                      reservation.GetReservationData());
                }

                break;
            case "4":
                Console.WriteLine("Enter client name:");
                string name = Console.ReadLine();
                Clients.FindAll(x => x.GetName().Contains(name)).ForEach(x =>
                    Reservations.FindAll(y => y.GetClient().GetName() == x.GetName())
                        .ForEach(y => Console.WriteLine(y.GetReservationData())));
                break;
            case "5":
                Console.WriteLine("Enter client phone number:");
                int phoneNumber = int.Parse(Console.ReadLine());
                Console.WriteLine(phoneNumber);
                Clients.FindAll(x => x.GetPhoneNumber() % 10000 == phoneNumber).ForEach(x => Reservations
                    .FindAll(x => x.GetClient().GetPhoneNumber() % 10000 == phoneNumber)
                    .ForEach(y => Console.WriteLine(y.GetReservationData())));
                break;
            case "7":
                Console.WriteLine("Enter location or none:");
                Console.WriteLine("Window - 0");
                Console.WriteLine("Exit - 1");
                Console.WriteLine("Deep - 2");
                Console.WriteLine("Passage - 3");
                TableLocation location = (TableLocation)Enum.Parse(typeof(TableLocation), Console.ReadLine());
                Console.WriteLine("Enter seats from 1 to 10 or none: ");
                int seats = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter slot from 8 to 21 (i.e. 10 for 10:00 - 11:00) or none: ");
                int time = int.Parse(Console.ReadLine());
                Tables.FindAll(x =>
                        x.GetTableLocation() == location && x.GetSeats() == seats && 
                        Reservations.FindAll(y => y.GetTable().GetTableId() == x.GetTableId())
                            .Find(z => z.SlotId == time) == null)
                    .ForEach(x => Console.WriteLine(x.GetTableData()));
                break;
            case "9":
                Console.WriteLine("Exit");
                break;
            case "8":
                Console.WriteLine("Enter table ID:");
                int editTableId = int.Parse(Console.ReadLine());
                if (Tables.Find(x => x.GetTableId() == editTableId) == null)
                {
                    Console.WriteLine("Table with provided ID not found");
                    break;
                }
                if (Reservations.Find(x => x.GetTable().GetTableId() == editTableId) != null)
                {
                    Console.WriteLine("Table is reserved");
                    break;
                }
                Console.WriteLine("Enter seats from 1 to 10:");
                int editingTableSeats = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter location:");
                Console.WriteLine("Window - 0");
                Console.WriteLine("Exit - 1");
                Console.WriteLine("Deep - 2");
                Console.WriteLine("Passage - 3");
                TableLocation eiditingTableLocation = (TableLocation)Enum.Parse(typeof(TableLocation), Console.ReadLine());
                Tables.Find(x => x.GetTableId() == editTableId).EditTable(editingTableSeats, eiditingTableLocation);
                break;
            default:
                Console.WriteLine("Invalid option");
                break;
        }
    }
}


Main();