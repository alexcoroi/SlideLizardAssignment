using Core;
using Microsoft.AspNetCore.Mvc;

namespace WebApi;

[ApiController]
[Route("api/[controller]")]
public class PresentationController : ControllerBase
{
    private readonly PresentationRepository presentationRepository;
    
    public PresentationController()
    {
        presentationRepository = new PresentationRepository();
    }

    [HttpGet]
    public ActionResult GetAllPresentations()
    {
        var presentations = presentationRepository.GetAllPresentations();
        return Ok(presentations);
    }
    
    [HttpGet("statistic")]
    public ActionResult GetStatistics(
        [FromQuery] DateTime fromdate,
        [FromQuery] DateTime todate)
    {
        if (fromdate > todate)
        {
            return BadRequest("fromdate must be earlier than todate.");
        }

        var statistics = presentationRepository.GetPresentationsBetweenDates(fromdate, todate);
        return Ok(statistics.Count());
    }

    [HttpPost]
    public ActionResult AddPresentation([FromBody] Presentation presentation)
    {
        try 
        {
            presentationRepository.Add(presentation);
            return CreatedAtAction(nameof(GetAllPresentations), new { name = presentation.Name }, presentation);
        }
        catch (InvalidOperationException ex)
        {
            return BadRequest(ex.Message);
        }
    }
}