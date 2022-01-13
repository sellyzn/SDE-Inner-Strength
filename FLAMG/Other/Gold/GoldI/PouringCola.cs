//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace FLAMG.Other.Gold.GoldI
//{
//    public class PouringCola
//    {
//        //不会啊啊啊啊
//        // BFS / Queue
//        public int GetMinTimes(int s, int n, int m)
//        {
//            if (s % 2 != 0)
//            {
//                return -1;
//            }

//            Queue<State> q = new Queue<State>();
//            var visited = new bool[s + 1, n + 1, m + 1];

//            q.Enqueue(new State(s, 0, 0));
//            visited[s, 0, 0] = true;
//            int dist = 0;
//            while (q.Count > 0)
//            {
//                int size = q.Count;
//                for (int i = 0; i < size; i++)
//                {
//                    State curr = q.Dequeue();
//                    if (curr.s == s / 2 && curr.n == s / 2 ||
//                        curr.s == s / 2 && curr.m == s / 2 ||
//                        curr.n == s / 2 && curr.m == s / 2)
//                    {
//                        return dist;
//                    }
//                    // 选择一个不空的杯子，倒入其他两个杯子
//                    var states = GetNextState(curr, s, n, m);
//                    foreach (State next in states)
//                    {
//                        if (visited[next.s, next.n, next.m])
//                        {
//                            continue;
//                        }
//                        visited[next.s, next.n, next.m] = true;
//                        q.Enqueue(new State(next.s, next.n, next.m));
//                    }
//                }
//                dist += 1;
//            }

//            return -1;
//        }

//        public IList<State> GetNextState(State state, int s, int n, int m)
//        {
//            var states = new List<State>();
//            if (state.s != 0)
//            {
//                int diff = Math.Min(n - state.n, state.s);
//                states.Add(new State(state.s - diff, state.n + diff, state.m));
//                diff = Math.Min(m - state.m, state.s);
//                states.Add(new State(state.s - diff, state.n, state.m + diff));
//            }
//            if (state.n != 0)
//            {
//                int diff = Math.Min(s - state.s, state.n);
//                states.Add(new State(state.s + diff, state.n - diff, state.m));
//                diff = Math.Min(m - state.m, state.n);
//                states.Add(new State(state.s, state.n - diff, state.m + diff));
//            }
//            if (state.m != 0)
//            {
//                int diff = Math.Min(s - state.s, state.m);
//                states.Add(new State(state.s + diff, state.n, state.m - diff));
//                diff = Math.Min(n - state.n, state.m);
//                states.Add(new State(state.s, state.n + diff, state.m - diff));
//            }
//            return states;
//        }


//        //II











//    }
//    public class State
//    {
//        public int s;
//        public int n;
//        public int m;
//        public State(int s, int n, int m)
//        {
//            this.s = s;
//            this.n = n;
//            this.m = m;
//        }
//    }
