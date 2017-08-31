using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Courses : MonoBehaviour
{
    public Course A, B, C, D, E, F, G, H, J, K, L, M, X, Y, Z;

    private void Start()
    {
#region InitializeAndAddDependencies
        A = new Course(30);
        B = new Course(30);
        C = new Course(30);

        D = new Course(50);
        D.AddDependency(A);
        D.AddDependency(B);

        E = new Course(50);
        E.AddDependency(B);

        F = new Course(50);
        F.AddDependency(B);
        F.AddDependency(C);

        G = new Course(50);
        G.AddDependency(C);

        H = new Course(70);
        H.AddDependency(D);
        H.AddDependency(E);
        H.AddDependency(F);

        J = new Course(70);
        J.AddDependency(A);
        J.AddDependency(B);
        J.AddDependency(C);
        J.AddDependency(D);
        J.AddDependency(E);
        J.AddDependency(F);
        J.AddDependency(G);

        K = new Course(70);
        K.AddDependency(H);
        K.AddDependency(J);
        K.AddDependency(L);
        K.AddDependency(M);

        L = new Course(70);
        L.AddDependency(F);
        L.AddDependency(G);

        M = new Course(70);
        M.AddDependency(G);

        X = new Course(100);
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

        Y = new Course(100);
        Y.AddDependency(H);
        Y.AddDependency(J);
        Y.AddDependency(K);
        Y.AddDependency(L);
        Y.AddDependency(M);

        Z = new Course(200);
        Z.AddDependency(X);
        Z.AddDependency(Y);
#endregion
    }
}