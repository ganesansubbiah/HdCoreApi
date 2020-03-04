using HDCoreApi.ApplicationCore.Entities;
namespace HDCoreApi.ApplicationCore.Repository
{    
    public abstract class OutputJsonRepositry
    {

        public string SUCCESS{
            get{
                return "SUCCESS";
                }
        }
        public string ERROR{
            get{
                return "ERROR";
            }
        }
        public int SUCCESS_STATUS{
            get{
                return 200;
            }
        }
        public int ERROR_STATUS{
            get {
                return 500;
            }
        }

        public OutPutJson GenerateOutputJson(string message, object result, int Count, int status,int RowsAffected)
        {
            OutPutJson outJson = new OutPutJson();

            outJson.Status = status;
            outJson.Response = result;
            outJson.Message = message;
            outJson.Count = Count;
            outJson.RowsAffected = RowsAffected;
            return outJson;
        }

        public OutPutJson GenerateErrorOutputJson(string message, object result)
        {
            OutPutJson outJson = new OutPutJson();

            outJson.Status = -1;
            outJson.Response = result;
            outJson.Message = message;
            return outJson;
        }
    }
}