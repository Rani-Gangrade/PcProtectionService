namespace PCProtectionShared
{
    public class SystemMetric
    {
        public int Id { get; set; }
        public decimal CpuUtilization { get; set; }
        public int MemoryUsedMb { get; set; }
        public int MemoryTotalMb { get; set; }
        public decimal MemoryUtilization { get; set; }
        public string SecurityEventType { get; set; }
        public string SecurityEventMessage { get; set; }
        public string Hostname { get; set; }
        public DateTime CollectedAt { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
