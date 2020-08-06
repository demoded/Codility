using System;
using System.Collections.Generic;
using System.Text;

namespace Codility
{
    public partial class CodilitySolutions
    {
        /// <summary>
        /// A string S consisting of N characters is called properly nested if:
        /// <list type="bullet">
        /// <item>S is empty;</item>
        /// <item>S has the form "(U)" where U is a properly nested string;</item>
        /// <item>S has the form "VW" where V and W are properly nested strings.</item>
        /// </list>
        /// Write a function that, given a string S consisting of N characters, returns 1 if string S is properly nested and 0 otherwise.
        /// <example>
        /// For example, given S = "(()(())())", the function should return 1 and given S = "())", the function should return 0.
        /// </example>
        /// Write an efficient algorithm for the following assumptions:
        /// <list type="bullet">
        /// <item>N is an integer within the range[0..1, 000, 000];</item>
        /// <item>string S consists only of the characters "(" and/or ")".</item>
        /// </list>
        /// </summary>
        /// <param name="S"></param>
        /// <returns></returns>
        public int Nesting(String S)
        {
            Stack<int> bracketsStack = new Stack<int>();

            for (int i = 0; i < S.Length; i++)
            {
                if (S[i] == '(')
                {
                    bracketsStack.Push(i);
                }
                else if (S[i] == ')')
                {
                    if (bracketsStack.Count > 0)
                    {
                        bracketsStack.Pop();
                    }
                    else
                    {
                        return 0;
                    }
                }
            }

            return bracketsStack.Count > 0 ? 0 : 1;
        }

        /// <summary>
        /// You are given two non-empty arrays A and B consisting of N integers. Arrays A and B represent N voracious fish in a river, ordered downstream along the flow of the river.
        /// The fish are numbered from 0 to N − 1. If P and Q are two fish and P<Q, then fish P is initially upstream of fish Q.Initially, each fish has a unique position.
        /// Fish number P is represented by A[P] and B[P]. Array A contains the sizes of the fish.All its elements are unique.Array B contains the directions of the fish.It contains only 0s and/or 1s, where:
        /// <list type="bullet">
        /// <item>0 represents a fish flowing upstream,</item>
        /// <item>1 represents a fish flowing downstream.</item>
        /// </list>
        /// If two fish move in opposite directions and there are no other (living) fish between them, they will eventually meet each other.Then only one fish can stay alive − the larger fish eats the smaller one.More precisely, we say that two fish P and Q meet each other when P &lt; Q, B[P] = 1 and B[Q] = 0, and there are no living fish between them. After they meet:
        /// <list type="bullet">
        /// <item>If A[P] &gt; A[Q] then P eats Q, and P will still be flowing downstream,</item>
        /// <item>If A[Q] &gt; A[P] then Q eats P, and Q will still be flowing upstream.</item>
        /// </list>
        /// We assume that all the fish are flowing at the same speed. That is, fish moving in the same direction never meet.The goal is to calculate the number of fish that will stay alive.
        /// <example>
        /// For example, consider arrays A and B such that:
        /// <list type="table">
        /// <item>A[0] = 4    B[0] = 0</item>
        /// <item>A[1] = 3    B[1] = 1</item>
        /// <item>A[2] = 2    B[2] = 0</item>
        /// <item>A[3] = 1    B[3] = 0</item>
        /// <item>A[4] = 5    B[4] = 0</item>
        /// </list>
        /// Initially all the fish are alive and all except fish number 1 are moving upstream.Fish number 1 meets fish number 2 and eats it, then it meets fish number 3 and eats it too.Finally, it meets fish number 4 and is eaten by it.The remaining two fish, number 0 and 4, never meet and therefore stay alive.
        /// </example>
        /// Write a function that, given two non-empty arrays A and B consisting of N integers, returns the number of fish that will stay alive.
        /// For example, given the arrays shown above, the function should return 2, as explained above.
        /// Write an efficient algorithm for the following assumptions:
        /// <list type="bullet">
        /// <item>N is an integer within the range[1..100, 000];</item>
        /// <item>each element of array A is an integer within the range[0..1, 000, 000, 000];</item>
        /// <item>each element of array B is an integer that can have one of the following values: 0, 1;</item>
        /// <item>the elements of A are all distinct.</item>
        /// </list>
        /// </summary>
        /// <param name="A"></param>
        /// <param name="B"></param>
        /// <returns></returns>
        public int Fish(int[] A, int[] B)
        {
            Stack<int> upstreamFish = new Stack<int>();
            int aliveFishCount = A.Length;

            for (int i = 0; i < A.Length; i++)
            {
                if (B[i] == 1)
                {
                    upstreamFish.Push(A[i]);
                }
                else
                {
                    while (upstreamFish.Count > 0)
                    {
                        //one must die
                        aliveFishCount--;

                        //let's find out who is bigger
                        if (upstreamFish.Peek() > (long)A[i])
                        {
                            //last upstream fish is bigger
                            break;
                        }
                        else
                        {
                            //last upstream fish has been eated
                            upstreamFish.Pop();
                        }
                    }
                }
            }

            return aliveFishCount;
        }

        /// <summary>
        /// Lesson 7.1 Brackets
        /// A string S consisting of N characters is considered to be properly nested if any of the following conditions is true:
        /// <list type="bullet">
        /// <item>S is empty;</item>
        /// <item>S has the form "(U)" or "[U]" or "{U}" where U is a properly nested string;</item>
        /// <item>S has the form "VW" where V and W are properly nested strings.</item>
        /// </list>
        /// Write a function that, given a string S consisting of N characters, returns 1 if S is properly nested and 0 otherwise.
        /// <example>
        /// For example, given S = "{[()()]}", the function should return 1 and given S = "([)()]", the function should return 0, as explained above.
        /// </example>
        /// Write an efficient algorithm for the following assumptions:
        /// <list type="bullet">
        /// <item>N is an integer within the range[0..200, 000];</item>
        /// <item>string S consists only of the following characters: "(", "{", "[", "]", "}" and/or ")".</item>
        /// </list>
        /// </summary>
        /// <param name="S"></param>
        /// <returns></returns>
        public int Brackets(String S)
        {
            Stack<char> bracketStack = new Stack<char>();

            if (S.Length == 0) return 1;
            if (S.Length % 2 == 1) return 0;

            bracketStack.Push(S[0]);

            for (int i = 1; i < S.Length; i++)
            {
                if (S[i] == '(' || S[i] == '[' || S[i] == '{')
                {
                    bracketStack.Push(S[i]);
                }
                else if (bracketStack.Count > 0)
                {
                    if ((S[i] == ')' && bracketStack.Peek() == '(') ||
                        (S[i] == ']' && bracketStack.Peek() == '[') ||
                        (S[i] == '}' && bracketStack.Peek() == '{'))
                    {
                        bracketStack.Pop();
                    }
                    else
                    {
                        //wrong closing bracket found
                        return 0;
                    }
                }
                else
                {
                    //closing bracket found without opening
                    return 0;
                }

            }

            return (bracketStack.Count == 0) ? 1 : 0;
        }
    }
}
