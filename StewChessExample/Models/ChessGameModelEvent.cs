namespace ChessGame.Models
{
    public class PieceMoveEvent
    { 
	    // Unique Id for the database itself, ALL data entries require unique ID.
	    public int Id { get; set; }
	    public int gameId { get; set; } = 1;
	    public string Piece { get; set; } = "Pawn";
		public string FromPosition { get; set; } = "e2";
		public string ToPosition { get; set; } = "e4";
		public string Turn { get; set; } = "1";
		public DateTime Timestamp { get; set; }
    }
}
