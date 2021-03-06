using System.ComponentModel.DataAnnotations;

namespace Mimirorg.TypeLibrary.Enums
{
    public enum ConnectorDirection
    {
        [Display(Name = "Input")]
        Input = 0,

        [Display(Name = "Output")]
        Output = 1,

        [Display(Name = "Bidirectional")]
        Bidirectional = 2
    }
}