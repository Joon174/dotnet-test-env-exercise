namespace ChessGame.Models
{
    public class ChessGameEvent
    {
	public int Id { get; set; }
	public string WhitePlayerName { get; set; } = "Jane";
	public string BlackPlayerName { get; set; } = "Doe";
	public DateTime StartTime { get; set; }
	public List<PieceMoveEvent> PieceMoveEvents { get; set; } = new List<PieceMoveEvent>();
    }
}
