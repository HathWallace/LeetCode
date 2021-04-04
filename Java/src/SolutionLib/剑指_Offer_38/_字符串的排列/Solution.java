package SolutionLib.剑指_Offer_38._字符串的排列;

import java.util.ArrayList;

class Solution {
    private int[] dict;
    private ArrayList<String> res;

    public String[] permutation(String s) {
        int slen=s.length();
        dict=new int[128];
        res=new ArrayList<>();
        BackTrack(0,slen,new char[slen]);
        int size=res.size();
        var output=new String[size];
        for(int i=0;i<size;i++){
            output[i]=res.get(i);
        }
        return output;
    }

    private void BackTrack(int len,int max,char[] sb){
        if(len==max){
            res.add(sb.toString());
            return;
        }
        for(int i=0;i<128;i++){
            if(dict[i]==0) continue;
            dict[i]--;
            sb[len]=(char)i;
            BackTrack(len+1,max,sb);
            dict[i]++;
        }
    }
}
