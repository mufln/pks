namespace pks_sem3;

class ReservationWindow
{
    private string _comment;
    public int SlotId;
    private Table _table;
    private Client _client;
    
    private ReservationWindow(Table table, string comment, int slotId, Client client)
    {
        _table = table;
        _comment = comment;
        _client = client;
        SlotId = slotId;
    }

    public static List<ReservationWindow> AddReservationWindow(List<ReservationWindow> reservationWindows, Client client, Table table, string comment, int slotId)
    {
        var exists = reservationWindows.Find(x => x.GetTable() == table && x.SlotId == slotId);
        if (exists != null)
        {
            return reservationWindows;
        }
        reservationWindows.Add(new ReservationWindow(table, comment, slotId, client));
        return reservationWindows;
    }
    
    public Table GetTable()
    {
        return _table;
    }
    
    public Client GetClient()
    {
        return _client;
    }

    public void EditReservation(string? comment = null, int? slotId = null, Client? client = null)
    {
        if (comment != null)
        {
            _comment = comment;
        }

        if (slotId != null)
        {
            SlotId = slotId.Value;
        }

        if (client != null)
        {
            _client = client;
        }
    }
    public string GetReservationData()
    {
        return string.Format("{0}:00 - {1}:00 ", SlotId, SlotId + 1) + _client.GetFormattedProperties();
    }

    public static List<ReservationWindow> DeleteReservationWindow(List<ReservationWindow> reservationWindows, Table table,
        int slotId)
    {
        var exists = reservationWindows.Find(x => x.GetTable() == table && x.SlotId == slotId);
        if (exists != null)
        {
            reservationWindows.Remove(exists);
        }
        return reservationWindows;
    }
}