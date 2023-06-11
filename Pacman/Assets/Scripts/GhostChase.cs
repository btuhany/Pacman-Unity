using UnityEngine;

public class GhostChase : IGhostStates
{
    public GhostStateID StateID => GhostStateID.Chase;
    Ghost _ghost;

    public GhostChase(Ghost ghost)
    {
        _ghost = ghost;

    }

    public void Enter()
    {
   
    }

    public void Exit()
    {
    }

    public void Update()
    {
    

    }

    public void OnNode(Node node)
    {
        if (_ghost.NodeDirectionLock) return;
        Vector2 tempPosLeftRight;
        Vector2 tempPosUpDown;

        Vector2 dirLeftRight;
        Vector2 dirUpDown;

        bool forcedUpDown = false;
        bool forcedLeftRight = false;

        if (_ghost.ChaseTarget.x >= _ghost.CurrentPos.x && node.IsRightAvailable && _ghost.Movement.CurrentDir != Vector2.left)
        {
            tempPosLeftRight = new Vector2(_ghost.CurrentPos.x + 1, _ghost.CurrentPos.y);
            dirLeftRight = Vector2.right;

        }
        else if (_ghost.ChaseTarget.x <= _ghost.CurrentPos.x && node.IsLeftAvailable && _ghost.Movement.CurrentDir != Vector2.right)
        {
            tempPosLeftRight = new Vector2(_ghost.CurrentPos.x - 1, _ghost.CurrentPos.y);
            dirLeftRight = Vector2.left;

        }
        else
        {
            forcedUpDown = true;
            tempPosLeftRight = _ghost.CurrentPos;
            dirLeftRight = _ghost.Movement.CurrentDir;
        }

        if (_ghost.ChaseTarget.y >= _ghost.CurrentPos.y && node.IsUpAvailable && _ghost.Movement.CurrentDir != Vector2.down)
        {
            tempPosUpDown = new Vector2(_ghost.CurrentPos.x, _ghost.CurrentPos.y + 1);
            dirUpDown = Vector2.up;

        }
        else if (_ghost.ChaseTarget.y <= _ghost.CurrentPos.y && node.IsDownAvailable && _ghost.Movement.CurrentDir != Vector2.up)
        {
            tempPosUpDown = new Vector2(_ghost.CurrentPos.x, _ghost.CurrentPos.y - 1);
            dirUpDown = Vector2.down;

        }
        else
        {
            forcedLeftRight = true;
            tempPosUpDown = _ghost.CurrentPos;
            dirUpDown = _ghost.Movement.CurrentDir;
        }

        float distanceLeftRight = Vector2.Distance(tempPosLeftRight, _ghost.ChaseTarget);
        float distanceUpDown = Vector2.Distance(tempPosUpDown, _ghost.ChaseTarget);

        if(forcedLeftRight && !forcedUpDown)
        {
            _ghost.Movement.SetNextDirection(dirLeftRight);
        }
        else if(forcedUpDown && !forcedLeftRight)
        {
            _ghost.Movement.SetNextDirection(dirUpDown);
        }
        else if(forcedUpDown && forcedLeftRight)
        {
            if (node.IsUpAvailable && _ghost.Movement.CurrentDir != Vector2.down)
            {
                _ghost.Movement.SetNextDirection(Vector2.up);

            }
            else if (node.IsLeftAvailable && _ghost.Movement.CurrentDir != Vector2.right)
            {
                _ghost.Movement.SetNextDirection(Vector2.left);

            }
            else if (node.IsDownAvailable && _ghost.Movement.CurrentDir != Vector2.up)
            {
                _ghost.Movement.SetNextDirection(Vector2.down);

            }
            else if (node.IsRightAvailable && _ghost.Movement.CurrentDir != Vector2.left)
            {
                _ghost.Movement.SetNextDirection(Vector2.right);
            }
        }

        if(distanceLeftRight > distanceUpDown)
        {
            _ghost.Movement.SetNextDirection(dirUpDown);
 
        }
        else if(distanceLeftRight < distanceUpDown)
        {
            _ghost.Movement.SetNextDirection(dirLeftRight);

        }
        else
        {
            if(node.IsUpAvailable && dirUpDown == Vector2.up)
            {
                _ghost.Movement.SetNextDirection(dirUpDown);

            }
            else if(node.IsLeftAvailable && dirLeftRight == Vector2.left)
            {
                _ghost.Movement.SetNextDirection(dirLeftRight);
  
            }
            else if (node.IsDownAvailable && dirUpDown == Vector2.down)
            {
                _ghost.Movement.SetNextDirection(dirUpDown);
 
            }
            else if (node.IsRightAvailable && dirLeftRight == Vector2.right)
            {
                _ghost.Movement.SetNextDirection(dirLeftRight);
            }
        }
    }
}