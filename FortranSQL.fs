open System
open MySql.Data.MySqlClient

[<EntryPoint>]
let main argv =
    use myConnection = new MySqlConnection()
    use myCommand = new MySqlCommand()
    
    Console.Write("Enter IP Address: ")
    let ipAddress = Console.ReadLine()

    Console.Write("Enter SQL Username: ")
    let Username = Console.ReadLine()

    Console.Write("Enter SQL Password: ")
    let Password = Console.ReadLine()

    let ConnectionString = "server=" + ipAddress + "; port=3306; uid=" + Username + 
                           "; password=" + Password + ";"

    let myConnection : MySqlConnection = new MySqlConnection(ConnectionString)
    let myCommand : MySqlCommand = new MySqlCommand()
    myConnection.Open()
    
    myCommand.Connection <- myConnection
    myCommand.CommandText <- "SELECT * FROM gcb.devicecodes"

    let reader = myCommand.ExecuteReader()

    while reader.Read() do
        let Code = reader.GetString(reader.GetOrdinal("Code"))
        let GCBCode = reader.GetString(reader.GetOrdinal("GCBCode"))
        let DeviceName = reader.GetString(reader.GetOrdinal("DeviceName"))
        Console.WriteLine("{0} {1} {2}", Code, GCBCode, DeviceName)

    myConnection.Close()

    0 // return an integer exit code
