using System.Collections.Generic;
using UnityEngine;

public class King : Piece
{
    public bool CheckForChecks()
    {
        Vector2 currentCoordinates = GetCoordinates();
        bool[,] checkMap = IsWhite ? logicManager.blackCheckMap : logicManager.whiteCheckMap;

        bool isInCheck = checkMap[(int)currentCoordinates.x, (int)currentCoordinates.y];
        //Debug.Log($"Checking position ({currentCoordinates.x}, {currentCoordinates.y}) for checks: {isInCheck}");
        return isInCheck;
    }
    protected override List<Vector2> GetPotentialMoves()
    {
        List<Vector2> legalMoves = new List<Vector2>();
        int[] directionsX = { 1, -1, 0, 0, 1, -1, 1, -1 };
        int[] directionsY = { 0, 0, 1, -1, 1, -1, -1, 1 };

        Vector2 currentCoordinates = GetCoordinates();

        for (int i = 0; i < 8; i++)
        {
            Vector2 newPosition = new Vector2(
                currentCoordinates.x + directionsX[i],
                currentCoordinates.y + directionsY[i]
            );

            if (!IsPositionWithinBoard(newPosition))
                continue;

            Piece pieceAtNewPosition = logicManager.boardMap[(int)newPosition.x, (int)newPosition.y];

            if (pieceAtNewPosition == null || pieceAtNewPosition.IsWhite != IsWhite)
            {
                legalMoves.Add(newPosition);
            }
        }

        return legalMoves;
    }

    public override List<Vector2> GetAttackedFields()
    {
        List<Vector2> attackedFields = new List<Vector2>();
        int[] directionsX = { 1, -1, 0, 0, 1, -1, 1, -1 };
        int[] directionsY = { 0, 0, 1, -1, 1, -1, -1, 1 };

        Vector2 currentCoordinates = GetCoordinates();

        for (int i = 0; i < 8; i++)
        {
            Vector2 attackedPosition = new Vector2(
                currentCoordinates.x + directionsX[i],
                currentCoordinates.y + directionsY[i]
            );

            if (IsPositionWithinBoard(attackedPosition))
            {
                attackedFields.Add(attackedPosition);
            }
        }

        return attackedFields;
    }


}
