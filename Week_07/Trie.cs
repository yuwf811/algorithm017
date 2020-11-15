public class Trie {
    public Trie[] children;
    public bool isEnd;

    /** Initialize your data structure here. */
    public Trie() {
        children = new Trie[26];
        isEnd = false;
    }
    
    /** Inserts a word into the trie. */
    public void Insert(string word) {
        if(string.IsNullOrWhiteSpace(word))
        {
            return;
        }
        var cur = this;
        foreach(var c in word)
        {
            if(cur.children[c - 'a'] == null)
            {
                cur.children[c - 'a'] = new Trie();
            }
            cur = cur.children[c - 'a'];
        }
        cur.isEnd = true;
    }
    
    /** Returns if the word is in the trie. */
    public bool Search(string word) {
        var trie = SearchNode(word);
        return trie != null && trie.isEnd;
    }
    
    /** Returns if there is any word in the trie that starts with the given prefix. */
    public bool StartsWith(string prefix) {
        var trie = SearchNode(prefix);
        return trie != null;
    }

    private Trie SearchNode(string prefix)
    {
        if(string.IsNullOrWhiteSpace(prefix))
        {
            return null;
        }
        var cur = this;
        foreach(var c in prefix)
        {
            if(cur.children[c - 'a'] == null)
            {
                return null;
            }
            cur = cur.children[c - 'a'];
        }
        return cur;
    }
}