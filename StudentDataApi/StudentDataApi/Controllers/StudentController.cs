using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Net;
using System.Xml.Linq;
using System.Xml.Xsl;

namespace StudentDataApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        [Route("GetStudent")]
        [HttpGet]
        public IActionResult GetStudent(string name)
        {
            var xml = XDocument.Load(@"C:\XSLT\Student.xml");

            // Load the style sheet.
            XslCompiledTransform xslt = new XslCompiledTransform();
            xslt.Load(@"C:\\Users\\6399\\source\\repos\\StudentDataApi\\StudentDataApi\\PolicyViewModel.xsl");

            // Execute the transform and output the results to a file.
            xslt.Transform("PolicyViewModelXml.xml", "NewPolicyViewModel.xml");

            var query = from c in xml.Descendants("student")
                        where c.Element("name").Value == name
                        select c;
            Student student = null;
            foreach (var item in query)
            {
                student = new Student();
                student.name = item.Element("name").Value;
                student.branch = item.Element("branch").Value;
                student.age = item.Element("age").Value;
                student.city = item.Element("city").Value;
            }
            if (student == null)
            {
                return NotFound();
            }
            return Ok(student);
        }

        [Route("GetStudent")]
        [HttpPost]
        public IActionResult PostStudent(string city)
        {
            var xml = XDocument.Load(@"C:\XSLT\Student.xml");

            var query = from c in xml.Descendants("student")
                        where c.Element("city").Value == city
                        select c;
            Student student = new Student();
            foreach (var item in query)
            {
                student.name = item.Element("name").Value;
                student.branch = item.Element("branch").Value;
                student.age = item.Element("age").Value;
                student.city = item.Element("city").Value;
            }
            if (student == null)
            {
                return NotFound();
            }
            return Ok(student);
        }
    }
	
	
}
