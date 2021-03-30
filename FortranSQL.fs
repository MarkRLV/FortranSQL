open System
open MySql.Data.MySqlClient

[<EntryPoint>]
let main argv =
    use myConnection = new MySqlConnection()
    use myCommand = new MySqlCommand()
    
    let ConnectionString = "server=(someIPAddress); port=3306; uid=Me; password=MyPassword;"
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
