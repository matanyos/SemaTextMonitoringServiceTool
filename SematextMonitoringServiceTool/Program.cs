using SemaTextMonitoringServiceTool;
using SemaTextMonitoringServiceTool.DTOs;

DisplayMenu();


void DisplayMenu()
{
    while (true)
    {
        Console.WriteLine("Select one of the options:" + "\n 1- Add New Monitor " + "\n 2- Get EndPoint Status");

        var input = Console.ReadLine();

        if (input is "1" or "2")
        {
            var operationType = input == "1"
                ? OperationType.CreateNewMonitor
                : OperationType.GetStatus;

            ExecuteOperation(operationType);
        }
    }
}

void ExecuteOperation(OperationType operation)
{
    var apiKey = Utilities.TryGetValue("Api Key: ");

    var semaTextHttpMonitorService = new SemaTextHttpMonitorService(new RequestSender(apiKey));

    var output = string.Empty;
    var appId = Utilities.TryGetValue("AppId: ");
    var name = Utilities.TryGetValue("EndPoint Name: ");

    switch (operation)
    {
        case OperationType.GetStatus:
            output = semaTextHttpMonitorService.GetEndPointHttpMonitorStatus(name, appId).Result;
            break;

        case OperationType.CreateNewMonitor:
        {
            var endPoint = Utilities.TryGetValue("EndPoint: ");
            var method = Utilities.TryGetHttpMethodValue();
            var interval = Utilities.TryGetIntervalValue();

            output = semaTextHttpMonitorService.CreateNewEndPointHttpMonitor(name, endPoint, appId, method, interval).Result;
        }
            break;
    }

    Console.WriteLine(output);
    Console.WriteLine("*****************************************************");
}