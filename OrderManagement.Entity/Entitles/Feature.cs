﻿namespace OrderManagement.Entity.Entitles
{
    public class Feature
    {
        public int FeatureID { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public bool IsShown { get; set; }
        public bool Status { get; set; }
    }
}
