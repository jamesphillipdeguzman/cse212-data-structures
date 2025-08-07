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
        // If parent node is empty then return false
        if (root.Data == null)
            return false;
        // Checks if the leaf nodes on the left and right are empty, also return false
        else if (root.Left == null || root.Right == null)
            return false;

        // Case when value passed is less than the parent node
        else if (value < root.Data)
            // Check for a match on the left hand sub tree
            if (root.Left.Data == value)
                return true;
            else
                // Otherwise, make a recursive call and walk down the tree to visit the child nodes
                return Contains(root.Left, value);

        // Case when value passed is greater than the parent node
        else if (value > root.Data)
            // Check for a match on the right hand sub tree
            if (root.Right.Data == value)
                return true;
            else
                // Otherwise, make a recursive call and walk down the tree to visit the child nodes
                return Contains(root.Right, value);

        else
            return true;


    }

    public int GetHeight()
    {
        // TODO Start Problem 4

        return 0; // Replace this line with the correct return statement(s)
    }
}