using SuperVApi.Models;
using SuperVCore.BusinessLogic;
using SuperVCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SuperVApi.Controllers.Api
{
    public class MachineStatusController : ApiController
    {
        public HttpResponseMessage Post(MachineStatus model)
        {
            try
            {
                //TODO: check validita
                var param = new UpsertMachineStatus()
                {
                    Counter = model.Counter,
                    MachineID = model.MachineID,
                    MachineStatus = model.MachineState,
                    Speed = model.Speed,
                    ProductCode = model.ProductCode,

                };

                var mgr = new MachineStatusManager();
                mgr.Upsert(param);

                return Request.CreateResponse(HttpStatusCode.Created);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
