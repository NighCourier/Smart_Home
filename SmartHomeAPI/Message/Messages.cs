namespace SmartHomeAPI.Message
{
    public class Messages
    {
        public string emptyModel;
        public string idTempAndHumidExist;
        public string idRelayExist;
        public string noTempAndHumid;
        public string noRelay;
        public string successSave;
        public string errorSave;
        public Messages()
        {
            emptyModel = "Model is Empty!!";
            idTempAndHumidExist = "Temperature and Humid ID already exist!!";
            idRelayExist = "Relay ID already exist!!";
            noTempAndHumid = "Temperature and Humidity does not Exist!!";
            noRelay = "Relay does not Exist!!";
            successSave = "Successfully Added!!";
            errorSave = "Error in Saving!!";
        }
    }
}
