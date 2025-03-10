using System.Collections.Generic;
using UnityEngine;

public class Pawn : Piece
{
    protected override List<Vector2> GetPotentialMoves()
    {
        List<Vector2> legalMoves = new List<Vector2>();
        Vector2 currentCoordinates = GetCoordinates();
        int direction = IsWhite ? 1 : -1;

        Vector2 forwardMove = new Vector2(currentCoordinates.x, currentCoordinates.y + direction);
        if (IsPositionWithinBoard(forwardMove) && logicManager.boardMap[(int)forwardMove.x, (int)forwardMove.y] == null)
        {
            legalMoves.Add(forwardMove);
        }

        if (HasMoved == 0)
        {
            Vector2 doubleForwardMove = new Vector2(currentCoordinates.x, currentCoordinates.y + (2 * direction));
            if (IsPositionWithinBoard(doubleForwardMove) && logicManager.boardMap[(int)forwardMove.x, (int)forwardMove.y] == null && logicManager.boardMap[(int)doubleForwardMove.x, (int)doubleForwardMove.y] == null)
            {
                legalMoves.Add(doubleForwardMove);
            }
        }

        Vector2 captureLeft = new Vector2(currentCoordinates.x - 1, currentCoordinates.y + direction);
        Vector2 captureRight = new Vector2(currentCoordinates.x + 1, currentCoordinates.y + direction);

        if (IsPositionWithinBoard(captureLeft) && logicManager.boardMap[(int)captureLeft.x, (int)captureLeft.y] != null)
        {
            Piece targetPiece = logicManager.boardMap[(int)captureLeft.x, (int)captureLeft.y];
            if (targetPiece != null && targetPiece.IsWhite != IsWhite)
            {
                legalMoves.Add(captureLeft);
            }
        }

        if (IsPositionWithinBoard(captureRight) && logicManager.boardMap[(int)captureRight.x, (int)captureRight.y] != null)
        {
            Piece targetPiece = logicManager.boardMap[(int)captureRight.x, (int)captureRight.y];
            if (targetPiece != null && targetPiece.IsWhite != IsWhite)
            {
                legalMoves.Add(captureRight);
            }
        }
        return legalMoves;
    }

    public override List<Vector2> GetAttackedFields()
    {
        List<Vector2> attackedFields = new List<Vector2>();
        int direction = IsWhite ? 1 : -1;
        
        Vector2 leftAttackMove = new Vector2(transform.position.x - 1, transform.position.z + direction);
        Vector2 rightAttackMove = new Vector2(transform.position.x + 1, transform.position.z + direction);

        if (IsPositionWithinBoard(leftAttackMove))
        {
            attackedFields.Add(leftAttackMove);
        }

        if (IsPositionWithinBoard(rightAttackMove))
        {
            attackedFields.Add(rightAttackMove);
        }

        return attackedFields;
    }


}
