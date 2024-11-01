using System.Diagnostics;

namespace pks_sem3;

class Table
{
    private static int _maxId = 0;
    private int _tableId = GetId();
    private TableLocation _tableLocation;
    private int _seats;


    public Table(int seats, TableLocation tableLocation)
    {
        _seats = seats;
        _tableLocation = tableLocation;
    }
    
    public int GetTableId()
    {
        return _tableId;
    }

    public TableLocation GetTableLocation()
    {
        return _tableLocation;
    }
    
    public int GetSeats()
    {
        return _seats;
    }
    public void EditTable(int? seats = null, TableLocation? location = null)
    {
        if (seats != null)
        {
            _seats = seats.Value;
        }

        if (location != null)
        {
            _tableLocation = location.Value;
        }
    }

    private static int GetId()
    {
        _maxId++;
        return _maxId;
    }

    public string GetTableData()
    {
        String res = String.Format("ID: {0}\n", _tableId);
        res += String.Format("Location: {0}\n", _tableLocation);
        res += String.Format("Passages: {0}\n", _seats);
        return res;
    }

    public static Table GenerateTable()
    {
        Random random = new Random();
        int seats = random.Next(1, 10);
        var tableLocation = Enum.GetValues(typeof(TableLocation));
        int locationIndex = random.Next(0, tableLocation.Length);
        return new Table(seats, (TableLocation)locationIndex);
    }
}