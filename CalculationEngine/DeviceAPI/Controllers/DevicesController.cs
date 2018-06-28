using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DeviceAPI.Models;

namespace DeviceAPI.Controllers
{
    public class DevicesController : ApiController
    {
        String stringAPI = "Test";

        List<Devices> listDevices = new List<Devices>()
        {
            new Devices { IdDevice = 1,  Mac = "00:1B:44:11:3A:B7",  NoV = 1, Value = 2005  },
            new Devices { IdDevice = 2,  Mac = "00:1B:44:11:5C:B8",  NoV = 1, Value = 2055  },
            new Devices { IdDevice = 3,  Mac = "00:1B:44:11:3C:B4",  NoV = 1, Value = 2055  },
        };

        [HttpGet]
        [Route("api/v1/Devices")]
        public IEnumerable<Devices> GetAllDevices()
        {
            return listDevices;
        }


        [HttpGet]
        [Route("api/v1/Devices/{dev}")]
        public IHttpActionResult GetDeviceInfo(long dev)
        {
            var deviceInfo = listDevices.FirstOrDefault(c => c.IdDevice == dev);

            if (deviceInfo == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            return Ok(deviceInfo);
        }


        [HttpPost]
        [Route("api/v1/Devices")]
        public IHttpActionResult AddDevice(Devices newDevices)
        {
            var IdDevice = listDevices.Count() + 1;
            newDevices.IdDevice = IdDevice;
            listDevices.Add(newDevices);
            return Ok(newDevices);
        }

        [HttpPut]
        [Route("api/v1/Devices")]
        public HttpResponseMessage UpdateDeviceInfo(Devices device)
        {
            Devices devices = listDevices.FirstOrDefault(c => c.IdDevice == device.IdDevice);

            if (devices == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            devices.Mac = device.Mac;
            devices.NoV = device.NoV;
            devices.Value = device.Value;

            return new HttpResponseMessage(HttpStatusCode.OK);
        }


        [HttpDelete]
        [Route("api/v1/Devices/{dev}")]
        public HttpResponseMessage DeleteDevice(int deviceID)
        {
            Devices device = listDevices.FirstOrDefault(c => c.IdDevice == deviceID);

            if (device == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            listDevices.Remove(device);

            return new HttpResponseMessage(HttpStatusCode.OK);
        }

    }
}
