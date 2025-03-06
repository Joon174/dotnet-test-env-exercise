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
        public string From { get; set; } = "e2";
        public string To { get; set; } = "e4";
        public string Turn { get; set; } = "1";
    }
}
