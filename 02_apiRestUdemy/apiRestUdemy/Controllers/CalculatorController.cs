using Microsoft.AspNetCore.Mvc;

namespace apiRestUdemy.Controllers;

[ApiController]
[Route("[controller]")]
public class CalculatorController : ControllerBase
{
 
    private readonly ILogger<CalculatorController> _logger;

    public CalculatorController(ILogger<CalculatorController> logger)
    {
        _logger = logger;
    }

    [HttpGet("sum/{firstNumber}/{secondNumber}")]
    public IActionResult Sum(string firstNumber, string secondNumber)
    {
        if(IsNumeric(firstNumber)&& IsNumeric(secondNumber))
        {
            var sum = ConvertToDecimal(firstNumber) + ConvertToDecimal(secondNumber);
            return Ok(sum.ToString());
        }
        return BadRequest("Invalid Input");
    }

    [HttpGet("subtraction/{firstNumber}/{secondNumber}")]
    public IActionResult Subtraction(string firstNumber, string secondNumber)
    {
        if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
        {
            var subtraction = ConvertToDecimal(firstNumber) - ConvertToDecimal(secondNumber);
            return Ok(subtraction.ToString());
        }
        return BadRequest("Invalid Input");
    }

    [HttpGet("multiplication/{firstNumber}/{secondNumber}")]
    public IActionResult Multiplication(string firstNumber, string secondNumber)
    {
        if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
        {
            var multiplaction = ConvertToDecimal(firstNumber) * ConvertToDecimal(secondNumber);
            return Ok(multiplaction.ToString());
        }
        return BadRequest("Invalid Input");
    }

    [HttpGet("division/{firstNumber}/{secondNumber}")]
    public IActionResult division(string firstNumber, string secondNumber)
    {
        if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
        {
            var division = ConvertToDecimal(firstNumber) / ConvertToDecimal(secondNumber)  ;
            return Ok(division.ToString());
        }
        return BadRequest("Invalid Input");
    }
    [HttpGet("squareroot/{firstNumber}")]
    public IActionResult SquareRoot(string firstNumber)
    {
        if (IsNumeric(firstNumber))
        {
            var squareroot = Math.Sqrt((double)ConvertToDecimal(firstNumber));
            return Ok(squareroot.ToString());
        }
        return BadRequest("Invalid Input");
    }


    private decimal ConvertToDecimal(string strNumber)
    {
        decimal decimalVal;
        if(decimal.TryParse(strNumber, out decimalVal))
        {
            return decimalVal;
        }
        return 0;
    }

    private bool IsNumeric(string strNumber)
    {
        double number;
        bool isNumber = double.TryParse(strNumber, System.Globalization.NumberStyles.Any, System.Globalization.NumberFormatInfo.InvariantInfo, out number); 
        
        return isNumber;
    }
}
