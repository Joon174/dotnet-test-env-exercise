namespace ChessGame.GameRequests
{
    public class StartGameReq
    {
        public string WhitePlayer { get; set; } = "Jane";
        public string BlackPlayer { get; set; } = "Doe";
    }

    public class MovePieceCommand
    {
        public string Piece { get; set; } = "Pawn";
        public string FromPosition { get; set; } = "e2";
        public string ToPosition { get; set; } = "e4";
        public string Turn { get; set; } = "1";
    }
}
