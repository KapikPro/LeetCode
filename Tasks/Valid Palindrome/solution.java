class Solution {
    public boolean isPalindrome(String s) {
        int indexF = -1, indexS = s.length();
        char First=s.charAt(0),Second=s.charAt(s.length() - 1);
        for (int i = 0; (i < s.length() / 2); i++) {
            indexF++;
            indexS--;
            if(indexF==indexS)
                return true;
            First=s.charAt(indexF);
            Second=s.charAt(indexS);
            while((First < 'a' || First > 'z') && (First < '0' || First > '9') && (First < 'A' || First > 'Z')){
                indexF++;
                if(indexF==indexS)
                    return true;
                First=s.charAt(indexF);
            }
            while((Second < 'a' || Second > 'z') && (Second < '0' || Second > '9') && (Second < 'A' || Second > 'Z')){
                indexS--;
                if(indexF==indexS)
                    return true;
                Second=s.charAt(indexS);
            }
            if(Character.toLowerCase(First)!=Character.toLowerCase(Second))
                return false;
            if(indexS-indexF==1)
                return true;
        }
        return true;
    }
}