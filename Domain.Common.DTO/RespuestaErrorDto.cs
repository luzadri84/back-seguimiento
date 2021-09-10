using System.Collections.Generic;

namespace MinCultura.Domain.Common.DTO
{
    public class RespuestaErrorDto
	{
		public int Estado
		{
			get;
			set;
		}

		public List<ErrorDto> Errores
		{
			get;
			set;
		}
	}
}
