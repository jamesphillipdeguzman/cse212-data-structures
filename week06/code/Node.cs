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
        // If the value is the same as the root then just skip it...
        if (value == Data)
        {
            return; // Ignore duplicates and exit right away
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

    public bool Contains(Node? root, int value)
    {
        //Node root = new(Data);
        //Right = new Node(value);
        //Left = new Node(value);
        if (root.Data == null || (root.Left == null || root.Right == null))
            return false;

        if (value < root.Data && root.Left != null)

            return Contains(root.Left, value);
        else if (value > root.Data && root.Right != null)
            return Contains(root.Right, value);
        else
            return true;

        // if (Data == value)
        // {
        //     return true;
        // }
        // else if (Right is not null && Right.Data == value)
        // {
        //     return true;
        // }
        // else if (Left is not null && Left.Data == value)
        // {
        //     return true;
        // }

        //return Contains(value);
    }

    public int GetHeight()
    {
        // TODO Start Problem 4

        return 0; // Replace this line with the correct return statement(s)
    }
}