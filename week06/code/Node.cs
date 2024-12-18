public class Node
{
    public int Data { get; set; }
    public Node? Right { get; private set; }
    public Node? Left { get; private set; }

    public Node(int data)
    {
        this.Data = data;
    }
  //random comment
    public void Insert(int value)
    {
        if (value == Data)
        {
            return;
        }

        if (value < Data)
        {
            // Insert to the left
            if (Left is null)
                Left = new Node(value);
            else
                Left.Insert(value);
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
        if (value == Data)
        {
            return true;
        }

        if (value < Data)
        {
            // Recursively search in the left subtree
            return Left?.Contains(value) ?? false;
        }
        else
        {
            // Recursively search in the right subtree
            return Right?.Contains(value) ?? false;
        }
        
    }

    public int GetHeight()
    {
        if (Left == null && Right == null)
        {
            return 1;
        }

        int leftHeight = Left?.GetHeight()?? 0;
        int rightHeight = Right?.GetHeight()?? 0;

        return 1 + Math.Max(leftHeight, rightHeight);
    }
}