using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.ObjectPool;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Object_Pool_Design_Pattern_CSharp_Example.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly ObjectPool<X> _pool;

        public ValuesController(ObjectPool<X> pool)
        {
            _pool = pool;
        }

        [HttpGet("[action]")]
        public IActionResult Get1()
        {

            var x1 = _pool.Get();
            x1.Count++;
            _pool.Return(x1);
            return Ok(x1.Count);
        }

        [HttpGet("[action]")]
        public IActionResult Get2()
        {
            var x1 = _pool.Get();
            x1.Count++;
            _pool.Return(x1);
            return Ok(x1.Count);
        }
    }
}

