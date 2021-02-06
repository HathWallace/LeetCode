## 设计数据结构

#### 1、LRU缓存——最近最少使用（146）

可以使用`LinkedHashMap`，但最好自己造轮子，设计`Node`类和`DoubleList`类

①`Node`类

~~~java
class Node {
    int key;
    int val;
    Node pre,next;

    public Node(int key, int val) {
        this.key = key;
        this.val = val;
    }
}
~~~

②`DoubleList`类，双向链表

~~~java
class DoubleList {
	//注意这个size属性
    int size;
    Node head = new Node(0,0);
    Node tail = new Node(0,0);
    public DoubleList() {
        //双向链表初始化
        head.next = tail;
        tail.pre = head;
        size = 0;
    }

    public int size() {
        return size;
    }

    //在链表头部加入最新的结点
    public void addFirst(Node node) {
        Node tmp = head.next;
        head.next = node;
        node.next = tmp;
        tmp.pre = node;
        node.pre = head;
        size++;
    }

    //删除指定的结点
    public void remove(Node node) {
        Node tmp1 = node.pre;
        Node tmp2 = node.next;
        tmp1.next = tmp2;
        tmp2.pre = tmp1;
        size--;
    }
    
    //删除最久未使用的结点
    public Node removeLast() {
        Node res = tail.pre;
        //注意api的复用
        remove(res);
        return res;
    }
}
~~~

③真正的实现

~~~java
class LRUCache {
    int capacity;
    //存储key和Node结点的映射
    Map<Integer,Node> map;
    //双向链表
    DoubleList list;

    public LRUCache(int capacity) {
        this.capacity = capacity;
        map = new HashMap<>();
        list = new DoubleList();
    }
    
    public int get(int key) {
        if (!map.containsKey(key)) return -1;
    
        Node oldNode = map.get(key);
        int res = oldNode.val;
        //API的复用
        put(key,res);
        return res;
    }
    
    public void put(int key, int value) {
        Node node = new Node(key,value);
        if (map.containsKey(key)) {
            //之前的结点
            Node oldNode = map.get(key);
            list.remove(oldNode);
            
        }else {
            //容量到上限了，需要删除最久未使用的结点
            if (capacity == list.size()) {
                Node removeNode = list.removeLast();
                map.remove(removeNode.key);
            }
        }
        //list和map都需要加入新值
        list.addFirst(node);
        map.put(key,node);
    }
}
~~~

#### 2、LFU缓存——最不经常使用缓存算法（460）

①关键数据结构

~~~java
	//key--->value的映射集合
    private Map<Integer,Integer> keyToValue;
    //key--->frequency的映射集合
    private Map<Integer,Integer> keyToFreq;
    //frequency--->keyList的映射集合，因为一个频率可能对应着多个key
    private Map<Integer,LinkedHashSet<Integer>> freqToKeylist;

    private int capacity;

    private int minFreq;

    public LFUCache(int capacity) {
        this.capacity = capacity;
        keyToValue = new HashMap<>();
        keyToFreq = new HashMap<>();
        freqToKeylist = new HashMap<>();
        this.minFreq = 0;
    }
~~~

②`get`方法

~~~java
public int get(int key) {
        if (!keyToValue.containsKey(key)) return -1;
        //频率加一
        increaseFreq(key);
        return keyToValue.get(key);
    }
~~~

③`put`方法

~~~java
public void put(int key, int value) {
        if (capacity <= 0) return;
        //如果包含key
        if (keyToValue.containsKey(key)) {
            keyToValue.put(key,value);
            //频率加一
            increaseFreq(key);
            return;
            
        }
        //不包含key

        //删除最小频率
        if (capacity <= keyToValue.size()) removeMinFreq();

        keyToValue.put(key,value);
        keyToFreq.put(key,1);
        freqToKeylist.putIfAbsent(1,new LinkedHashSet<Integer>());
        freqToKeylist.get(1).add(key);
        //新加入元素的频率为1
        this.minFreq = 1;
    }
~~~

![image-20210203192218253](https://gitee.com/LJH1997/the-drawing-bed-of-ljh/raw/master/img/image-20210203192218253.png)

④频率加一`increaseFreq`方法

~~~java
	//频率加1方法
    //涉及到keyToFreq，freqToKeylist，minFreq的更新(总的来说跟频率相关的集合和变量进行调整)
    public void increaseFreq(int key) {
        int oldFreq = keyToFreq.get(key);
        freqToKeylist.get(oldFreq).remove(key);
        keyToFreq.put(key,oldFreq+1);
        freqToKeylist.putIfAbsent(oldFreq+1,new LinkedHashSet<Integer>());
        freqToKeylist.get(oldFreq+1).add(key);
        //看看之前频率oldFreq对应的keyList删除key后是否空了
        if (freqToKeylist.get(oldFreq).isEmpty()) {
            freqToKeylist.remove(oldFreq);
            //因为刚刚更新的frequency是oldFreq+1，所以只需要+1就行了
            if (this.minFreq == oldFreq) {
                this.minFreq++;
            }
        }
    }
~~~

⑤`removeMinFreq`方法

~~~java
	//删除最小频率所对应的最久没使用的元素   要调整所对应的一系列集合和变量
    public void removeMinFreq() {
        
        LinkedHashSet<Integer> keylist = freqToKeylist.get(minFreq);
        int deleteKey = keylist.iterator().next();
        keylist.remove(deleteKey);
        if (keylist.isEmpty()) {
            freqToKeylist.remove(minFreq);
            //不需要进行minFreq的更新.因为是capacity不足的时候才会来到这个方法，肯定有最小频率是1
        }
        keyToValue.remove(deleteKey);
        keyToFreq.remove(deleteKey);
    }
~~~

#### 3、Union-Find算法（并查集，可以解决有向图问题）

需要实现的API：

~~~java
class UF {
    /* 将 p 和 q 连接 */
    public void union(int p, int q);
    /* 判断 p 和 q 是否连通 */
    public boolean connected(int p, int q);
    /* 返回图中有多少个连通分量 如果全部结点都连接，则连通分量为0*/
    public int count();
}
~~~

完整实现：

~~~java
class UF{
    //连通分量
    private int count;
    //可以理解为上一层父结点
    private int[] parent;
    //结点的重量，即连通元素的总数
    private int[] size;
    
    public UF(int n) {
        count = n;
        parent = new int[n];
        size = new int[n];
       	for (int i=0;i<n;i++) {
            parent[i] = i;
            size[i] = 1;
        }
    }
    
    public void union(int p, int q) {
        int rootP = find(p);
        int rootQ = find(q);
        //结点重量小的接在重量大的根节点上
        if (size[rootP] > size[rootQ]) {
            parent[rootQ] = rootP;
            size[rootP] += size[rootQ];
        }else {
            parent[rootP] = rootQ;
            size[rootQ] += size[rootP];
        }
        count--;
    }
    //寻找根节点
    public int find(int x) {
        while (parent[x] != x) {
            //压缩路径
            parent[x] = parent[parent[x]];
            x = parent[x];
        }
        return x;
    }
    
    //判断两个结点是否连通
    public boolean connected(int p, int q) {
        int rootP = find(p);
        int rootQ = find(q);
        return rootP == rootQ;
    }
    
    public int count() {
        return count;
    }
}
~~~

---

例题1：等式方程的可满足性（990）

~~~java
class Solution {
    public boolean equationsPossible(String[] equations) {
        //26个字母
        UF uf = new UF(26);

        for (String s:equations) {
            char ch = s.charAt(1);
            //表示是==，连通的
            if (ch == '=') {
                uf.union(s.charAt(0)-'a',s.charAt(s.length()-1)-'a');
            }
        }

        for (String s:equations) {
            char ch = s.charAt(1);
            if (ch == '!') {
                if (uf.connected(s.charAt(0)-'a',s.charAt(s.length()-1)-'a')) return false;
            }
        }
        return true;
    }
}
~~~

例题2：除法求值（399）

①带权值的`UF`

~~~java
class UF{
    private int[] parent;
    private double[] weight;

    public UF(int n) {
        parent = new int[n];
        weight = new double[n];
        for (int i=0;i<n;i++) {
            parent[i] = i;
            weight[i] = 1.0d;
        }
    }

    public void union(int p, int q, double value) {
        int rootP = find(p);
        int rootQ = find(q);
        if (rootP == rootQ) return;
        parent[rootP] = rootQ;
        //见下图1
        weight[rootP] = weight[q]*value/weight[p];
    }

    public int find(int x) {
        //注意是if，不是while。全部挂在根节点上
        if (x != parent[x]) {
            int tmp = parent[x];
            parent[x] = find(parent[x]);
            weight[x] *= weight[tmp];
        }
        return parent[x];
    }

    //由p指向q
    public double connected(int p,int q) {
        int rootP = find(p);
        int rootQ = find(q);
        if (rootQ != rootP) {
            return -1.0d;
        }else {
            return weight[p]/weight[q];
        }
    }
}
~~~

![image-20210203214422787](https://gitee.com/LJH1997/the-drawing-bed-of-ljh/raw/master/img/image-20210203214422787.png)



②具体实现

~~~java
class Solution {
    public double[] calcEquation(List<List<String>> equations, double[] values, List<List<String>> queries) {
        int equationSize = equations.size();
        //每个equation有两个结点
        UF uf = new UF(2*equationSize);
        //把结点由字符串映射为int类型
        Map<String,Integer> map = new HashMap<>(2*equationSize);
        int id = 0;
        //开始映射,并构建连通
        for (int i=0;i<equationSize;i++) {
            List<String> equation = equations.get(i);
            String node1 = equation.get(0);
            String node2 = equation.get(1);

            if (!map.containsKey(node1)) {
                map.put(node1,id);
                id++;
            }
            if (!map.containsKey(node2)) {
                map.put(node2,id);
                id++;
            }
            uf.union(map.get(node1),map.get(node2),values[i]);
        }

        double[] res = new double[queries.size()];
        for (int i=0;i<queries.size();i++) {
            List<String> query = queries.get(i);
            String node1 = query.get(0);
            String node2 = query.get(1);

            if (map.get(node1) == null || map.get(node2) == null) {
                res[i] = -1.0d;
            }else {
                res[i] = uf.connected(map.get(node1),map.get(node2));
            }
        }
        return res;

    }
}
~~~

#### 4、双栈实现队列(232)

~~~java
class MyQueue {

    LinkedList<Integer> stack1;
    LinkedList<Integer> stack2;

    /** Initialize your data structure here. */
    public MyQueue() {
        //队尾
        stack1 = new LinkedList<>();
        //对头
        stack2 = new LinkedList<>();

    }
    
    /** Push element x to the back of queue. */
    public void push(int x) {
        stack1.addLast(x);
    }
    
    /** Removes the element from in front of queue and returns that element. */
    public int pop() {
        //需要先peek一下！！！
        int head = peek();
        stack2.removeLast();
        return head;
    }
    
    /** Get the front element. */
    public int peek() {
        if (stack2.isEmpty()) {
            while (!stack1.isEmpty()) {
                stack2.addLast(stack1.removeLast());
            }
        }
        return stack2.getLast();
    }
    
    /** Returns whether the queue is empty. */
    public boolean empty() {
        return stack1.isEmpty() && stack2.isEmpty();
    }
}
~~~

#### 5、双队列实现栈（225）

~~~java
class MyStack {

    LinkedList<Integer> queue;
    LinkedList<Integer> tmpQueue;
    /** Initialize your data structure here. */
    public MyStack() {
        queue = new LinkedList<>();
        tmpQueue = new LinkedList<>();
    }
    
    /** Push element x onto stack. */
    public void push(int x) {
        while (!queue.isEmpty()) {
            tmpQueue.addLast(queue.removeFirst());
        }
        while (!tmpQueue.isEmpty()) {
            queue.addLast(tmpQueue.removeFirst());
        }
        queue.addLast(x);
    }
    
    /** Removes the element on top of the stack and returns that element. */
    public int pop() {
        int res = queue.removeLast();
        return res;
    }
    
    /** Get the top element. */
    public int top() {
        return queue.peekLast();
    }
    
    /** Returns whether the stack is empty. */
    public boolean empty() {
        return queue.isEmpty();
    }
}
~~~

#### 6、最小栈（155）

~~~java
class MinStack {

    Deque<Integer> stack;
    //minstack的栈顶是最小值
    Deque<Integer> minStack;
    /** initialize your data structure here. */
    public MinStack() {
        stack = new ArrayDeque<>();
        minStack = new ArrayDeque<>();
    }
    
    public void push(int x) {
        stack.addLast(x);
        //注意是>=号
        if (minStack.size() == 0 || minStack.getLast() >= x) {
            minStack.addLast(x);
        }
        
    }
    
    public void pop() {
        int tmp = stack.removeLast();
        if (tmp == minStack.getLast()) {
            minStack.removeLast();
        }
    }
    
    public int top() {
        return stack.getLast();
    }
    
    public int getMin() {
        return minStack.getLast();
    }
}
~~~

#### 7、前缀树（208）

~~~java
class Trie {
    //该结点是否是结束的标志
    private boolean is_end = false;
    //一个结点下有26个分支，对应着26个字母
    private Trie[] next;


    /** Initialize your data structure here. */
    public Trie() {
        next = new Trie[26];
    }
    
    /** Inserts a word into the trie. */
    public void insert(String word) {
        Trie root = this;
        char[] wordArr = word.toCharArray();
        for (int i=0;i<wordArr.length;i++) {
            if (root.next[wordArr[i]-'a'] == null) {
                root.next[wordArr[i]-'a'] = new Trie();
            }
            root = root.next[wordArr[i]-'a'];
        }
        root.is_end = true;
    }
    
    /** Returns if the word is in the trie. */
    public boolean search(String word) {
        Trie root = this;
        for (int i=0;i<word.length();i++) {
            char ch = word.charAt(i);
            if (root.next[ch-'a'] == null) return false;
            root = root.next[ch-'a'];
        }
        return root.is_end;
    }
    
    /** Returns if there is any word in the trie that starts with the given prefix. */
    public boolean startsWith(String prefix) {
        Trie root = this;
        for (int i=0;i<prefix.length();i++) {
            char ch = prefix.charAt(i);
            if (root.next[ch-'a'] == null) return false;
            root = root.next[ch-'a'];
        }
        //跟search相比就是这个地方不一样
        return true;
    }
}
~~~

#### 8、手写一个阻塞队列（生产者消费者模式 ）

~~~java
public class MyBlockingQueue<T> {
    private final int capacity;
    private final LinkedList<T> queue;
    private final ReentrantLock lock;
    //消费者条件队列
    private final Condition nullCondition;
    //生产者条件队列
    private final Condition fullCondition;

    public MyBlockingQueue(int capacity) {
        this.capacity = capacity;
        queue = new LinkedList<>();
        lock = new ReentrantLock();
        nullCondition = lock.newCondition();
        fullCondition = lock.newCondition();
    }

    public T remove() {
        lock.lock();
        try {
            try {
                while (queue.isEmpty()) {
                    System.out.println("队列空了。。。");
                    nullCondition.await();

                }
            }catch (InterruptedException e) {
                e.printStackTrace();
            }

            T res = queue.removeFirst();
            System.out.println("消费者消费"+res);
            fullCondition.signal();
            return res;
        } finally {
            lock.unlock();
        }

    }

    public void add(T num) {
        lock.lock();
        try {
            try {

            while (queue.size() == capacity) {
                System.out.println("队列满了。。。");
                    fullCondition.await();
                }

            } catch (InterruptedException e) {
                e.printStackTrace();
            }
            System.out.println("生产者生产一个。。。");
            queue.addLast(num);
            nullCondition.signal();
        } finally {
            lock.unlock();
        }
    }
}
~~~

测试：

~~~java
public class TestMyBockingQueue {
    public static void main(String[] args) {
        MyBlockingQueue<Integer> blockingQueue = new MyBlockingQueue<>(3);
        Thread t1 = new Thread(()->{
            for (int i = 0; i < 100; i++) {
                blockingQueue.remove();
            }
        },"消费者线程");

        Thread t2 = new Thread(()->{
            for (int i = 0; i < 100; i++) {
                blockingQueue.add(i);
            }
        },"生产者线程");
        t1.start();
        t2.start();
    }
}
~~~

#### 9、设计一个简单的线程池

①手写设计阻塞队列，即任务队列

~~~java
public class MyBlockingQueue<T> {

    private final int capacity;
    private final LinkedList<T> queue;
    private final ReentrantLock lock = new ReentrantLock();
    private final Condition nullCondition = lock.newCondition();
    private final Condition fullCondition = lock.newCondition();

    public MyBlockingQueue(int capacity) {
        this.capacity = capacity;
        this.queue = new LinkedList<>();
    }

    //带超时获取
    public T poll(long timeout, TimeUnit timeUnit) {
        lock.lock();
        try {
            long timeNano = timeUnit.toNanos(timeout);
            while (queue.isEmpty()) {
                try {
                    if (timeNano <= 0) return null;
                    timeNano = nullCondition.awaitNanos(timeNano);
                } catch (InterruptedException e) {
                    e.printStackTrace();
                }
            }
            //获取任务
            T t = queue.removeFirst();
            fullCondition.signal();
            return t;

        }finally {
            lock.unlock();
        }
    }

    //阻塞添加
    public void put(T task) {
        lock.lock();
        try{
            while (queue.size() == capacity) {
                try {
                    System.out.println("等待加入任务队列"+task);
                    fullCondition.await();
                } catch (InterruptedException e) {
                    e.printStackTrace();
                }
            }
            System.out.println("加入任务队列"+task);
            queue.addLast(task);
            nullCondition.signal();//唤醒消费者，可以来取了
        }finally {
            lock.unlock();
        }
    }

    public void offer(T task, long timeout, TimeUnit timeUnit) {
        lock.lock();
        try {

            long timeNano = timeUnit.toNanos(timeout);
            try {
                while (queue.size() == capacity) {
                    if (timeout <=0 ) return;
                    timeout = fullCondition.awaitNanos(timeNano);
                }

            } catch (InterruptedException e) {
                e.printStackTrace();
            }
            System.out.println("开始添加");
            queue.addLast(task);
            nullCondition.signal();

        }finally {
            lock.unlock();
        }
    }

    public int size() {
        lock.lock();
        try {
            return queue.size();
        }finally {
            lock.unlock();
        }
    }

    //工作线程达到最大线程数后执行此方法（拒绝策略or加入任务队列）
    public void tryPut(RejectPolicy<T> rejectPolicy,T task) {
        lock.lock();
        try {
            //如果任务队列也满了
            if (queue.size() == capacity) {
                //执行拒绝策略
                rejectPolicy.reject(this,task);
            }else { //任务队列没满
                //加入任务队列
                System.out.println("加入任务");
                queue.addLast(task);
                nullCondition.signal();
            }

        }finally {
            lock.unlock();
        }
    }
}
~~~

②定义拒绝策略接口

~~~java
public interface RejectPolicy<T> {
    void reject(MyBlockingQueue<T> blockingQueue,T task);
}
~~~

③设计线程池类，其中有一个真正的工作线程类——`Worker`类，属于线程池的内部类。

~~~java
public class MyThreadPool {

    private final int pollsize;
    private final MyBlockingQueue<Runnable> taskQueue;
    private final long timeout;
    private final TimeUnit timeUnit;
    private final RejectPolicy<Runnable> rejectPolicy;
    //工作线程集合
    private final Set<Worker> workerSet;

    public MyThreadPool(int pollsize, MyBlockingQueue<Runnable> taskQueue,
                        long timeout, TimeUnit timeUnit, RejectPolicy<Runnable> rejectPolicy) {
        this.pollsize = pollsize;
        this.taskQueue = taskQueue;
        this.timeout = timeout;
        this.timeUnit = timeUnit;
        this.rejectPolicy = rejectPolicy;
        workerSet = new HashSet<>();
    }

    public void execute(Runnable task) {
        synchronized (workerSet) {
            if (workerSet.size() < pollsize) {
                //将task包装为Worker
                Worker worker = new Worker(task);
                //新创建的线程要先进入工作线程集合中
                System.out.println("新增worker"+worker+"  任务队列"+task);
                workerSet.add(worker);
                worker.start();
            }else {
                //工作线程数达到上限，需要加入taskQueue或者执行拒绝策略
                taskQueue.tryPut(rejectPolicy,task);
            }
        }

    }


    class Worker extends Thread {
        private Runnable task;

        public Worker(Runnable task) {
            this.task = task;
        }

        @Override
        public void run() {
            //执行任务
            //当task不为空，执行任务
            //当task执行完毕，再接着从任务队列获取任务并执行
            while (task != null || (task = taskQueue.poll(timeout,timeUnit)) != null) {

                //开始执行任务
                System.out.println("正在执行。。。" + task);
                task.run();
                //注意执行完之后要设为null
                task = null;

            }
            synchronized (workerSet) {
                System.out.println("worker被移除"+this);
                workerSet.remove(this);
            }
        }
    }

}
~~~

④测试

~~~java
public class TestThreadPool {
    public static void main(String[] args) {
        MyBlockingQueue<Runnable> taskQueue = new MyBlockingQueue<>(1);
        MyThreadPool threadPool = new MyThreadPool(1, taskQueue, 2, TimeUnit.SECONDS, (queue, task) -> {
            //拒绝策略：死等
            queue.put(task);
        });

        for (int i = 0; i < 10; i++) {
            int index = i;
            threadPool.execute(()->{
                System.out.println("ljh--------------------"+index);
            });
        }


    }
}
~~~

#### 10、循环数组实现队列

~~~java
public class QueueArray<T>{

    T[] arr;
    int head;
    int tail;
    int size;

    public QueueArray(int size){
        this.size = size;
        head = 0;
        tail = 0;
        arr =(T[]) new Object[size+1];
    }

    public QueueArray(){
        this(4);
    }

    public void addLast(T item) {
        if ((tail+1)% arr.length == head) throw new RuntimeException("队列满了，不能添加元素！");
        arr[tail] = item;
        tail = (tail+1)% arr.length;
    }

    public T removeFirst() {
        if (head == tail) {
            throw new RuntimeException("队列为空，不能移除元素！");
        }

        T res = arr[head];
        head = (head+1)% arr.length;
        return res;
    }
    
}
~~~

#### 11、手写一个简单的HashMap（类似与JDK1.7 采用拉链法解决hash冲突，插入时采用头插法，未考虑扩容）

~~~java
/**
 * Created by LJH on 2021/2/6 21:07
 */
public class MyHashMap<K,V>{

    //将(key,value)包装成Entry键值对来存储
    private class Entry<K,V> {
        int hash;
        K key;
        V value;
        Entry<K,V> next;

        public Entry(int hash, K key, V value, Entry<K, V> next) {
            this.hash = hash;
            this.key = key;
            this.value = value;
            this.next = next;
        }
    }
    //默认容量
    private static final int DEFAULT_CAPACITY = 16;
    //装结点的桶（数组）
    private final Entry<K,V>[] table;
    //map中entry的数量
    private int size;
    //table的容量
    private final int capacity;

    public MyHashMap(int capacity) {
        this.table = new Entry[capacity];
        size = 0;
        this.capacity = capacity;
    }

    public MyHashMap(){
        this(DEFAULT_CAPACITY);
    }

    //采用JDK1.8中的hash函数,让hashcode的高16位和低16位都参与运算，散列值更好
    //允许加入key=null，存储在第0个桶中
    public int hash(K key) {
        int h;
        return (key == null) ? 0 : (h = key.hashCode()) ^ (h >>> 16);
    }

    public int size() {
        return size;
    }

    public boolean isEmpty() {
        return size == 0;
    }

    public void put(K key,V value) {
        Entry<K,V> newEnrty = new Entry(hash(key),key,value,null);
        //找到key所对应桶的位置
        int index = (capacity-1)&hash(key);
        Entry<K,V> entry = table[index];
        while (entry != null) {
            //entry.key == null是key为null
            if (entry.key == null || entry.key.equals(key)) {
                entry.value = value;
                return;
            }
            entry = entry.next;
        }
        //运用头插法插入新结点
        newEnrty.next = table[index];
        table[index] = newEnrty;
        size++;
    }

    public V get(K key) {
        int index = (capacity-1)&hash(key);
        Entry<K,V> entry = table[index];
        //如果对应桶中不存在元素，直接返回null
        if (entry == null) {
            return null;
        }
        while (entry != null) {
            
            if (entry.key == null || entry.key.equals(key)) {
                return entry.value;
            }
            entry = entry.next;
        }
        //找到链表末尾也没找到，返回null
        return null;
    }
}
~~~

测试：

~~~java
public class TestMyHashMap {
    public static void main(String[] args) {
        MyHashMap<Integer, Integer> map = new MyHashMap<>();
        map.put(1,11);
        map.put(2,22);
        map.put(null,2);
        map.put(null,3);
        map.put(null,4);
        System.out.println(map.get(null));
        System.out.println(map.size());
        System.out.println(map.isEmpty());

    }
}
~~~







