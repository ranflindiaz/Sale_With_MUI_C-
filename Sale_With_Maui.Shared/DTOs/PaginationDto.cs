﻿namespace Sale_With_Maui.Shared.DTOs
{
    public class PaginationDto
    {
        public int Id { get; set; }

        public int Page { get; set; } = 1;

        public int RecordsNumber { get; set; } = 10;

        public string? Filter { get; set; }
    }
}
