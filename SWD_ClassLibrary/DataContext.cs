using Microsoft.EntityFrameworkCore;
using SWData;

public class DataContext : DbContext
{
    public DbSet<Activity> Activities { get; set; }
    public DbSet<HeartRate> HeartRates { get; set; }
    public DbSet<Sleep> Sleeps { get; set; }
    public DbSet<Workout> Workouts { get; set; }
    public DbSet<Step> Steps { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database = SmartwatchData; " +
            "Integrated Security = True; Trusted_Connection = true; MultipleActiveResultSets = True");
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var workout = modelBuilder.Entity<Workout>();
        var sleep = modelBuilder.Entity<Sleep>();
        var activity = modelBuilder.Entity<Activity>();
        var step = modelBuilder.Entity<Step>();
        var heartrate = modelBuilder.Entity<HeartRate>();
        workout.ToTable("Workouts");
        sleep.ToTable("Sleeps");
        activity.ToTable("Activities");
        step.ToTable("Steps");
        heartrate.ToTable("HeartRates");

        modelBuilder.Entity<HeartRate>(
        b =>
        {
            b.HasKey("_id");
            b.Property(e => e.LowestHR);
            b.Property(e => e.HighestHR);
            b.Property(e => e.Average);
            b.Property(e => (e.Range));
        });
        modelBuilder.Entity<Activity>(
        b =>
       {
           b.HasKey("_id");
           b.Property(e => (e.Date)).HasColumnType("DateTime");
           b.Property(e => (e.Duration));
           b.Property(e => (e.Goal));
       });
        modelBuilder.Entity<Workout>(
       b =>
       {  
           b.HasOne(e => e.HeartRate);
           b.HasOne(e => e.Step); // hasOne jer nije property nego FK
           b.Property(e => e.Activity_id);
           b.Property(e => (e.Duration));
           b.Property(e => (e.Date));
           b.Property(e => (e.Intensity));
           b.Property(e => (e.Goal));
       });
        modelBuilder.Entity<Sleep>(
      b =>
      {
          b.Property(e => (e.Date));
          b.Property(e => (e.Duration));
          b.Property(e => (e.Quality));
          b.Property(e => (e.Goal));
          b.Property(e => e.Activity_id);
      });
        modelBuilder.Entity<Step>(
      b =>
      {
          b.HasKey("_id");
          b.Property(e => (e.StepCount));
          b.Property(e => (e.StepGoal));
      });
        base.OnModelCreating(modelBuilder);
    }
}

