using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Courses : MonoBehaviour
{
    public Course A, B, C, D, E, F, G, H, J, K, L, M, X, Y, Z;

    private void Start()
    {
#region InitializeAndAddDependencies
        A = new Course(30, "A");
        B = new Course(30, "B");
        C = new Course(30, "C");

        D = new Course(50, "D");
        D.AddDependency(A);
        D.AddDependency(B);

        E = new Course(50, "E");
        E.AddDependency(B);

        F = new Course(50, "F");
        F.AddDependency(B);
        F.AddDependency(C);

        G = new Course(50, "G");
        G.AddDependency(C);

        H = new Course(70, "H");
        H.AddDependency(D);
        H.AddDependency(E);
        H.AddDependency(F);

        J = new Course(70, "J");
        J.AddDependency(A);
        J.AddDependency(B);
        J.AddDependency(C);
        J.AddDependency(D);
        J.AddDependency(E);
        J.AddDependency(F);
        J.AddDependency(G);

        K = new Course(70, "K");
        K.AddDependency(H);
        K.AddDependency(J);
        K.AddDependency(L);
        K.AddDependency(M);

        L = new Course(70, "L");
        L.AddDependency(F);
        L.AddDependency(G);

        M = new Course(70, "M");
        M.AddDependency(G);

        X = new Course(100, "X");
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

        Y = new Course(100, "Y");
        Y.AddDependency(H);
        Y.AddDependency(J);
        Y.AddDependency(K);
        Y.AddDependency(L);
        Y.AddDependency(M);

        Z = new Course(200, "Z");
        Z.AddDependency(X);
        Z.AddDependency(Y);
#endregion
    }
}