using System.Timers;

public class Node
{
    public int Data { get; set; }
    public Node? Right { get; private set; }
    public Node? Left { get; private set; }

    public Node(int data)
    {
        this.Data = data;
    }

    public void Insert(int value)
    {
        // TODO Start Problem 1
        if (this.Data == value)
        {
            // Value already exists in the tree
            return;
        }

        if (value < Data)
        {
            // Insert to the left
            {
                if (Left is null)
                    Left = new Node(value);
                else
                    Left.Insert(value);
            }
        }
        else
        {
            // Insert to the right
            if (Right is null)
                Right = new Node(value);
            else
                Right.Insert(value);
        }
    }

    public bool Contains(int value)
    {
        // TODO Start Problem 2
        if (this.Data == value)
        {
            return true;
        }
        else if (Left is not null && Left.Contains(value))
        {
            return true;
        }
        else if (Right is not null && Right.Contains(value))
        {
            return true;
        }

        return false;
    }

    public int GetHeight()
    {
        // TODO Start Problem 4

        //If left is not null, call GetHeight() on the left node
        //If left is null, then the height is 0
        int leftHeight = Left?.GetHeight() ?? 0;

        //If right is not null, call GetHeight() on the right node
        //If right is null, then the height is 0
        int rightHeight = Right?.GetHeight() ?? 0;

        // Return the greater of the two heights plus one for the current node
        return Math.Max(leftHeight, rightHeight) + 1;
    }
}