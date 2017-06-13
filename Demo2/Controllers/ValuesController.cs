using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace Demo.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            int guidLenght = Guid.NewGuid().ToString().Length;

            //null Exception Demo
            string myString = "";
            int length = myString.Length;

            //tuple Demo
            object[] numbers = { 1, null, "4", 8, 16, 32, 0b100_0000, new object[] { 5, 7, 8} };

            var t = Tally(numbers);

            return new string[] { "value1", "value2", t.ToString() };
        }

        private (int sum, int total) Tally(object[] values)
        {
            var r = (s: 0, c: 0);

            foreach (var value in values)
            {
                //smudge example
                int j;

                switch (value)
                {
                    case int i:
                        Add(i, 1);
                        break;
                    case object[] a when a.Length > 0:
                        var (sum, count) = Tally(a);
                        Add(sum, count);
                        break;
                    case object[] _:
                    case null:
                        break;
                    case string s when int.TryParse(s, out j):
                        Add(j, 1);
                        break;
                    default:
                        throw new ArgumentException("Not a number");
                }
            }

            return r;

            void Add(int s, int c) => r = (r.s + s, r.c + c);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
