using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Courses : MonoBehaviour
{
    public Course A, B, C, D, E, F, G, H, J, K, L, M, X, Y, Z;
    public int[] courseValues;

    private void Start()
    {
        courseValues = new int[15];
        for(int i = 0; i < courseValues.Length; i++)
        {
            courseValues[i] = i + 1;
        }
#region InitializeAndAddDependencies
        A = new Course(30, 1);
        B = new Course(30, 2);
        C = new Course(30, 3);

        D = new Course(50, 4);
        D.AddDependency(A);
        D.AddDependency(B);

        E = new Course(50, 5);
        E.AddDependency(B);

        F = new Course(50, 6);
        F.AddDependency(B);
        F.AddDependency(C);

        G = new Course(50, 7);
        G.AddDependency(C);

        H = new Course(70, 8);
        H.AddDependency(D);
        H.AddDependency(E);
        H.AddDependency(F);

        J = new Course(70, 9);
        J.AddDependency(A);
        J.AddDependency(B);
        J.AddDependency(C);
        J.AddDependency(D);
        J.AddDependency(E);
        J.AddDependency(F);
        J.AddDependency(G);

        K = new Course(70, 10);
        K.AddDependency(H);
        K.AddDependency(J);
        K.AddDependency(L);
        K.AddDependency(M);

        L = new Course(70, 11);
        L.AddDependency(F);
        L.AddDependency(G);

        M = new Course(70, 12);
        M.AddDependency(G);

        X = new Course(100, 13);
        X.AddDependency(A);
        X.AddDependency(B);
        X.AddDependency(C);
        X.AddDependency(D);
        X.AddDependency(E);
        X.AddDependency(F);
        X.AddDependency(G);
        X.AddDependency(H);
        X.AddDependency(J);
        X.AddDependency(K);
        X.AddDependency(L);
        X.AddDependency(M);

        Y = new Course(100, 14);
        Y.AddDependency(H);
        Y.AddDependency(J);
        Y.AddDependency(K);
        Y.AddDependency(L);
        Y.AddDependency(M);

        Z = new Course(200, 15);
        Z.AddDependency(X);
        Z.AddDependency(Y);
#endregion
    }
}