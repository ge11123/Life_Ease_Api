﻿namespace LifeManage.src.Domain.Entities
{
    public class StoreVisit
    {
		public int StoreVisitId { get; set; }
		public int StoreId { get; set; }
		public DateTime DateVisited { get; set; }
		public int UserId { get; set; }
	}
}
