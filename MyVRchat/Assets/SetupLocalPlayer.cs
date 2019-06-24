using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class SetupLocalPlayer : NetworkBehaviour
{
    public BlendshapeDriver blendshapeDriver;

    public SkinnedMeshRenderer skinnedMeshRenderer;

    [SyncVar]
    public float blendShape0;
    [SyncVar]
    public float blendShape1;
    
    [SyncVar]
    public float blendShape2;
    
    [SyncVar]
    public float blendShape31;
    
    [SyncVar]
    public float blendShape36;
    
    [SyncVar]
    public float blendShape5;
    
    [SyncVar]
    public float blendShape37;
    
    [SyncVar]
    public float blendShape39;
    
    [SyncVar]
    public float blendShape41;
    
    [SyncVar]
    public float blendShape42;
    
    [SyncVar]
    public float blendShape10;
    [SyncVar]
    public float blendShape11;
    
    [SyncVar]
    public float blendShape12;
    [SyncVar]
    public float blendShape13;
    
    [SyncVar]
    public float blendShape14;
    
    [SyncVar]
    public float blendShape15;
    
    [SyncVar]
    public float blendShape16;
    
    [SyncVar]
    public float blendShape17;
    
    [SyncVar]
    public float blendShape18;
    
    [SyncVar]
    public float blendShape19;
    
    [SyncVar]
    public float blendShape20;
    
    [SyncVar]
    public float blendShape21;
    
    [SyncVar]
    public float blendShape44;
    [SyncVar]
    public float blendShape23;
    
    [SyncVar]
    public float blendShape45;
    [SyncVar]
    public float blendShape48;
    
    [SyncVar]
    public float blendShape49;
    
    
    [SyncVar]
    public float blendShape28;
    
    [SyncVar]
    public float blendShape29;
    
    
    /*
    
    [SyncVar]
    public float blendShape31;
    
    [SyncVar]
    public float blendShape32;
    
    [SyncVar]
    public float blendShape33;
    
    [SyncVar]
    public float blendShape34;
    [SyncVar]
    public float blendShape35;
    
    [SyncVar]
    public float blendShape36;
    [SyncVar]
    public float blendShape37;
    
    [SyncVar]
    public float blendShape38;
    
    [SyncVar]
    public float blendShape39;
    
    [SyncVar]
    public float blendShape40;
    
    [SyncVar]
    public float blendShape41;
    
    [SyncVar]
    public float blendShape42;
    
    [SyncVar]
    public float blendShape43;
    
    [SyncVar]
    public float blendShape44;
    
    [SyncVar]
    public float blendShape45;
    
    [SyncVar]
    public float blendShape46;
    [SyncVar]
    public float blendShape47;
    
    [SyncVar]
    public float blendShape48;
    [SyncVar]
    public float blendShape49;
    
    [SyncVar]
    public float blendShape50;
    
 */

    public Vector3 offset = new Vector3(0, 0.5f, 0.4f);

    public static SetupLocalPlayer localPlayerInstance;
    
    public override void OnStartLocalPlayer()
    {
        base.OnStartLocalPlayer();
        localPlayerInstance = this;
    }
    [Command]
    public void CmdPauseGame()
    {
        /*
        Time.timeScale = 0.0f;
        RpcPauseGame();
        */
    }

    [ClientRpc]
    public void RpcPauseGame()
    {
        /*
        Debug.Log("PAUSE");
        //RPScontroller.instance.serverRPS.SetActive(false);
        //RPScontroller.instance.clientRPS.SetActive(false);
        Time.timeScale = 0.0f;
    */
    }
    
    
    
    public static bool isServerReady = false;
    public static bool isClientReady = false;
    
    [Command]
    public void CmdResumeGame(bool serverCall, bool clientCall)
    {
        RpcResumeGame(serverCall, clientCall);
    }

    
    [ClientRpc]
    public void RpcResumeGame(bool serverCall, bool clientCall)
    {
        if (serverCall && !isServerReady)
        {
            isServerReady = true;
        }
        
        if (clientCall && !isClientReady)
        {
            isClientReady = true;
        }

        if (isServerReady && isClientReady)
        {
            isServerReady = false;
            isClientReady = false;
            Debug.Log("RESUME");
            //RPScontroller.instance.serverRPS.SetActive(true);
            //RPScontroller.instance.clientRPS.SetActive(true);
            //Time.timeScale = 1.0f;
            RoundManager.instance.gamePaused = false;
        }
        
    }
    
    [Command]
    public void CmdRock2()
    {
        
        MultiPlayer.instance.rockClicked2 = true;
        RpcRock2();
    }
    
    [ClientRpc]
    public void RpcRock2()
    {
        Debug.Log("PLAYER2_ROCK");
        MultiPlayer.instance.rockClicked2= true;
    }

    [Command]
    public void CmdPaper2()
    {
        MultiPlayer.instance.paperClicked2 = true;
        RpcPaper2();
    }
    
    [ClientRpc]
    public void RpcPaper2()
    {
        Debug.Log("PLAYER2_PAPER");
        MultiPlayer.instance.paperClicked2 = true;
    }
    
    [Command]
    public void CmdScissors2()
    {
        MultiPlayer.instance.scissorsClicked2 = true;
        RpcScissors2();
    }
    
    [ClientRpc]
    public void RpcScissors2()
    {
        Debug.Log("PLAYER2_SCISSORS");
        MultiPlayer.instance.scissorsClicked2 = true;
    }

    
    // Start is called before the first frame update
    void Start()
    {
        if (isLocalPlayer)
        {
            //Debug.Log("LOCAL PLAYER SPAWNED");
            UnityARFaceAnchorManager.instance.anchorPrefab = gameObject;
            blendshapeDriver.enabled = true;
            InvokeRepeating("UpdateBlendshapes",5, 0.05f);
        }
        else
        {
            Debug.Log("NOT LOCAL PLAYER SPAWNED");
            blendshapeDriver.enabled = false;
        }
        
    }

    private void LateUpdate()
    {
        if (isLocalPlayer)
        {
            return;
        }
        
        //Camera.main.transform.position = transform.position - transform.forward * 0.4f + transform.up * 0.1f;
        //Camera.main.transform.position = transform.position + offset;
        Camera.main.transform.position = Vector3.zero + Vector3.up * transform.position.y;
        Camera.main.transform.LookAt(transform.position);
        
    }

    
    
    public void UpdateBlendshapes()
    {
        if (!isLocalPlayer)
        {
            return;
        }
        
        if (isServer)
        {
            GetBlendshapes();
        }
        else
        {
            float[] clientsWeights = new float[31]; // = new List<float>();

            GetBlendshapes();
            
            clientsWeights[0] = blendShape0;
            clientsWeights[1] = blendShape1;
            clientsWeights[2] = blendShape2;
            clientsWeights[3] = blendShape31;
            clientsWeights[4] = blendShape36;
            clientsWeights[5] = blendShape5;
            clientsWeights[6] = blendShape37;
            clientsWeights[7] = blendShape39;
            clientsWeights[8] = blendShape41;
            clientsWeights[9] = blendShape42;
            clientsWeights[10] = blendShape10;
            clientsWeights[11] = blendShape11;
            clientsWeights[12] = blendShape12;
            clientsWeights[13] = blendShape13;
            clientsWeights[14] = blendShape14;
            clientsWeights[15] = blendShape15;
            clientsWeights[16] = blendShape16;
            clientsWeights[17] = blendShape17;
            clientsWeights[18] = blendShape18;
            clientsWeights[19] = blendShape19;
            clientsWeights[20] = blendShape20;
            clientsWeights[21] = blendShape21;
            clientsWeights[22] = blendShape44;
            clientsWeights[23] = blendShape23;
            clientsWeights[24] = blendShape45;
            clientsWeights[25] = blendShape48;
            clientsWeights[26] = blendShape49;
            clientsWeights[28] = blendShape28;
            clientsWeights[29] = blendShape29;
            
            /*
            clientsWeights.Add(blendShape0);
            clientsWeights.Add(blendShape1);
            clientsWeights.Add(blendShape2);
            clientsWeights.Add(blendShape3);
            clientsWeights.Add(blendShape4);
            clientsWeights.Add(blendShape5);
            clientsWeights.Add(blendShape6);
            clientsWeights.Add(blendShape7);
            clientsWeights.Add(blendShape8);
            clientsWeights.Add(blendShape9);
            clientsWeights.Add(blendShape10);
            clientsWeights.Add(blendShape11);
            clientsWeights.Add(blendShape12);
            clientsWeights.Add(blendShape13);
            clientsWeights.Add(blendShape14);
            clientsWeights.Add(blendShape15);
            clientsWeights.Add(blendShape16);
            clientsWeights.Add(blendShape17);
            clientsWeights.Add(blendShape18);
            clientsWeights.Add(blendShape19);
            clientsWeights.Add(blendShape20);
            clientsWeights.Add(blendShape21);
            clientsWeights.Add(blendShape22);
            clientsWeights.Add(blendShape23);
            clientsWeights.Add(blendShape24);
            clientsWeights.Add(blendShape25);
            clientsWeights.Add(blendShape26);
            clientsWeights.Add(blendShape27);
            clientsWeights.Add(blendShape28);
            clientsWeights.Add(blendShape29);
            clientsWeights.Add(blendShape30)*/
            
            CmdGetBlendShapes(clientsWeights);
        }
        
        /*
        blendShape0 = skinnedMeshRenderer.GetBlendShapeWeight(0);
        
        blendShape1 = skinnedMeshRenderer.GetBlendShapeWeight(1);
        
        blendShape2 = skinnedMeshRenderer.GetBlendShapeWeight(2);
        
        blendShape3 = skinnedMeshRenderer.GetBlendShapeWeight(3);
        
        blendShape4 = skinnedMeshRenderer.GetBlendShapeWeight(4);
        
        blendShape5 = skinnedMeshRenderer.GetBlendShapeWeight(5);
        
        blendShape6 = skinnedMeshRenderer.GetBlendShapeWeight(6);
        
        blendShape7 = skinnedMeshRenderer.GetBlendShapeWeight(7);
        
        blendShape8 = skinnedMeshRenderer.GetBlendShapeWeight(8);
        
        blendShape9 = skinnedMeshRenderer.GetBlendShapeWeight(9);
        
        blendShape10 = skinnedMeshRenderer.GetBlendShapeWeight(10);
        
        blendShape11 = skinnedMeshRenderer.GetBlendShapeWeight(11);
        
        blendShape12 = skinnedMeshRenderer.GetBlendShapeWeight(12);
        
        blendShape13 = skinnedMeshRenderer.GetBlendShapeWeight(13);
        
        blendShape14 = skinnedMeshRenderer.GetBlendShapeWeight(14);
        
        blendShape15 = skinnedMeshRenderer.GetBlendShapeWeight(15);
        
        blendShape16 = skinnedMeshRenderer.GetBlendShapeWeight(16);
        
        blendShape17 = skinnedMeshRenderer.GetBlendShapeWeight(17);
        
        blendShape18 = skinnedMeshRenderer.GetBlendShapeWeight(18);
        
        blendShape19 = skinnedMeshRenderer.GetBlendShapeWeight(19);
        
        blendShape20 = skinnedMeshRenderer.GetBlendShapeWeight(20);
        
        blendShape21 = skinnedMeshRenderer.GetBlendShapeWeight(21);
        
        blendShape22 = skinnedMeshRenderer.GetBlendShapeWeight(22);
        
        blendShape23 = skinnedMeshRenderer.GetBlendShapeWeight(23);
        
        blendShape24 = skinnedMeshRenderer.GetBlendShapeWeight(24);
        
        blendShape25 = skinnedMeshRenderer.GetBlendShapeWeight(25);
        
        blendShape26 = skinnedMeshRenderer.GetBlendShapeWeight(26);
        
        blendShape27 = skinnedMeshRenderer.GetBlendShapeWeight(27);
        
        blendShape28 = skinnedMeshRenderer.GetBlendShapeWeight(28);
        
        blendShape29 = skinnedMeshRenderer.GetBlendShapeWeight(29);
        
        blendShape30 = skinnedMeshRenderer.GetBlendShapeWeight(30);
        
        /*
        blendShape31 = skinnedMeshRenderer.GetBlendShapeWeight(31);
        
        blendShape32 = skinnedMeshRenderer.GetBlendShapeWeight(32);
        
        blendShape33 = skinnedMeshRenderer.GetBlendShapeWeight(33);
        
        blendShape34 = skinnedMeshRenderer.GetBlendShapeWeight(34);
        
        blendShape35 = skinnedMeshRenderer.GetBlendShapeWeight(35);
        
        blendShape36 = skinnedMeshRenderer.GetBlendShapeWeight(36);
        
        blendShape37 = skinnedMeshRenderer.GetBlendShapeWeight(37);
        
        blendShape38 = skinnedMeshRenderer.GetBlendShapeWeight(38);
        
        blendShape39 = skinnedMeshRenderer.GetBlendShapeWeight(39);
        
        blendShape40 = skinnedMeshRenderer.GetBlendShapeWeight(40);
        
        blendShape41 = skinnedMeshRenderer.GetBlendShapeWeight(41);
        
        blendShape42 = skinnedMeshRenderer.GetBlendShapeWeight(42);
        
        blendShape43 = skinnedMeshRenderer.GetBlendShapeWeight(43);
        
        blendShape44 = skinnedMeshRenderer.GetBlendShapeWeight(44);
        
        blendShape45 = skinnedMeshRenderer.GetBlendShapeWeight(45);
        
        blendShape46 = skinnedMeshRenderer.GetBlendShapeWeight(46);
        
        blendShape47 = skinnedMeshRenderer.GetBlendShapeWeight(47);
        
        blendShape48 = skinnedMeshRenderer.GetBlendShapeWeight(48);
        
        blendShape49 = skinnedMeshRenderer.GetBlendShapeWeight(49);
        
        blendShape50 = skinnedMeshRenderer.GetBlendShapeWeight(50);
        */
    }
    
    
    
    private void Update()
    {
        if (isLocalPlayer)
        {
            return;
        }
        
        SetBlendshapes();
        
        /*
        if (isServer)
        {
            RpcSetBlendShapes();
        }
        else
        {
            CmdSetBlendShapes();
        }
        */
        
        //CmdSetBlendShapes();
        
        /*
        skinnedMeshRenderer.SetBlendShapeWeight(31, blendShape31);
        
        skinnedMeshRenderer.SetBlendShapeWeight(32, blendShape32);
        
        skinnedMeshRenderer.SetBlendShapeWeight(33, blendShape33);
        
        skinnedMeshRenderer.SetBlendShapeWeight(34, blendShape34);
        
        skinnedMeshRenderer.SetBlendShapeWeight(35, blendShape35);
        
        skinnedMeshRenderer.SetBlendShapeWeight(36, blendShape36);
        
        skinnedMeshRenderer.SetBlendShapeWeight(37, blendShape37);
        
        skinnedMeshRenderer.SetBlendShapeWeight(38, blendShape38);
        
        skinnedMeshRenderer.SetBlendShapeWeight(39, blendShape39);
        
        skinnedMeshRenderer.SetBlendShapeWeight(40, blendShape40);
        
        skinnedMeshRenderer.SetBlendShapeWeight(41, blendShape41);
        
        skinnedMeshRenderer.SetBlendShapeWeight(42, blendShape42);
        
        skinnedMeshRenderer.SetBlendShapeWeight(43, blendShape43);
        
        skinnedMeshRenderer.SetBlendShapeWeight(44, blendShape44);
        
        skinnedMeshRenderer.SetBlendShapeWeight(45, blendShape45);
        
        skinnedMeshRenderer.SetBlendShapeWeight(46, blendShape46);
        
        skinnedMeshRenderer.SetBlendShapeWeight(47, blendShape47);
        
        skinnedMeshRenderer.SetBlendShapeWeight(48, blendShape48);
        
        skinnedMeshRenderer.SetBlendShapeWeight(49, blendShape49);
        
        skinnedMeshRenderer.SetBlendShapeWeight(50, blendShape50);
        */
        
        //CmdSetBlendShapes();
        
    }

     [Command]
    public void CmdGetBlendShapes(float[] clientsWeights)
    {
        blendShape0 = clientsWeights[0];
        blendShape1 = clientsWeights[1];
        blendShape2 = clientsWeights[2];
        blendShape31 = clientsWeights[3];
        blendShape36 = clientsWeights[4];
        blendShape5 = clientsWeights[5];
        blendShape37 = clientsWeights[6];
        blendShape39 = clientsWeights[7];
        blendShape41 = clientsWeights[8];
        blendShape42 = clientsWeights[9];
        blendShape10 = clientsWeights[10];
        blendShape11 = clientsWeights[11];
        blendShape12 = clientsWeights[12];
        blendShape13 = clientsWeights[13];
        blendShape14 = clientsWeights[14];
        blendShape15 = clientsWeights[15];
        blendShape16 = clientsWeights[16];
        blendShape17 = clientsWeights[17];
        blendShape18 = clientsWeights[18];
        blendShape19 = clientsWeights[19];
        blendShape20 = clientsWeights[20];
        blendShape21 = clientsWeights[21];
        blendShape44 = clientsWeights[22];
        blendShape23 = clientsWeights[23];
        blendShape45 = clientsWeights[24];
        blendShape48 = clientsWeights[25];
        blendShape49 = clientsWeights[26];
        blendShape28 = clientsWeights[28];
        blendShape29 = clientsWeights[29];
        
        //GetBlendshapes();
        
        //RpcSetBlendShapes();
    }
    
    
    [ClientRpc]
    public void RpcGetBlendShapes()
    {
        GetBlendshapes();
    }


    public void GetBlendshapes()
    {
        blendShape0 = skinnedMeshRenderer.GetBlendShapeWeight(0);
        
        blendShape1 = skinnedMeshRenderer.GetBlendShapeWeight(1);
        
        blendShape2 = skinnedMeshRenderer.GetBlendShapeWeight(2);
        
        blendShape31 = skinnedMeshRenderer.GetBlendShapeWeight(31);
        
        blendShape36 = skinnedMeshRenderer.GetBlendShapeWeight(36);
        
        blendShape5 = skinnedMeshRenderer.GetBlendShapeWeight(5);
        
        blendShape37 = skinnedMeshRenderer.GetBlendShapeWeight(37);
        
        blendShape39 = skinnedMeshRenderer.GetBlendShapeWeight(39);
        
        blendShape41 = skinnedMeshRenderer.GetBlendShapeWeight(41);
        
        blendShape42 = skinnedMeshRenderer.GetBlendShapeWeight(42);
        
        blendShape10 = skinnedMeshRenderer.GetBlendShapeWeight(10);
        
        blendShape11 = skinnedMeshRenderer.GetBlendShapeWeight(11);
        
        blendShape12 = skinnedMeshRenderer.GetBlendShapeWeight(12);
        
        blendShape13 = skinnedMeshRenderer.GetBlendShapeWeight(13);
        
        blendShape14 = skinnedMeshRenderer.GetBlendShapeWeight(14);
        
        blendShape15 = skinnedMeshRenderer.GetBlendShapeWeight(15);
        
        blendShape16 = skinnedMeshRenderer.GetBlendShapeWeight(16);
        
        blendShape17 = skinnedMeshRenderer.GetBlendShapeWeight(17);
        
        blendShape18 = skinnedMeshRenderer.GetBlendShapeWeight(18);
        
        blendShape19 = skinnedMeshRenderer.GetBlendShapeWeight(19);
        
        blendShape20 = skinnedMeshRenderer.GetBlendShapeWeight(20);
        
        blendShape21 = skinnedMeshRenderer.GetBlendShapeWeight(21);
        
        blendShape44 = skinnedMeshRenderer.GetBlendShapeWeight(44);
        
        blendShape23 = skinnedMeshRenderer.GetBlendShapeWeight(23);
        
        blendShape45 = skinnedMeshRenderer.GetBlendShapeWeight(45);
        
        blendShape48 = skinnedMeshRenderer.GetBlendShapeWeight(48);
        
        blendShape49 = skinnedMeshRenderer.GetBlendShapeWeight(49);
        
        
        blendShape28 = skinnedMeshRenderer.GetBlendShapeWeight(28);
        
        blendShape29 = skinnedMeshRenderer.GetBlendShapeWeight(29);
        
    }

    [Command]
    public void CmdSetBlendShapes()
    {
        SetBlendshapes();
        
        //RpcSetBlendShapes();
    }
    
    
    [ClientRpc]
    public void RpcSetBlendShapes()
    {
        SetBlendshapes();
    }


    public void SetBlendshapes()
    {
        skinnedMeshRenderer.SetBlendShapeWeight(0, blendShape0);
        
        skinnedMeshRenderer.SetBlendShapeWeight(1, blendShape1);
        
        skinnedMeshRenderer.SetBlendShapeWeight(2, blendShape2);
        
        skinnedMeshRenderer.SetBlendShapeWeight(31, blendShape31);
        
        skinnedMeshRenderer.SetBlendShapeWeight(36, blendShape36);
        
        skinnedMeshRenderer.SetBlendShapeWeight(5, blendShape5);
        
        skinnedMeshRenderer.SetBlendShapeWeight(37, blendShape37);
        
        skinnedMeshRenderer.SetBlendShapeWeight(39, blendShape39);
        
        skinnedMeshRenderer.SetBlendShapeWeight(41, blendShape41);
        
        skinnedMeshRenderer.SetBlendShapeWeight(42, blendShape42);
        
        skinnedMeshRenderer.SetBlendShapeWeight(10, blendShape10);
        
        skinnedMeshRenderer.SetBlendShapeWeight(11, blendShape11);
        
        skinnedMeshRenderer.SetBlendShapeWeight(12, blendShape12);
        
        skinnedMeshRenderer.SetBlendShapeWeight(13, blendShape13);
        
        skinnedMeshRenderer.SetBlendShapeWeight(14, blendShape14);
        
        skinnedMeshRenderer.SetBlendShapeWeight(15, blendShape15);
        
        skinnedMeshRenderer.SetBlendShapeWeight(16, blendShape16);
        
        skinnedMeshRenderer.SetBlendShapeWeight(17, blendShape17);
        
        skinnedMeshRenderer.SetBlendShapeWeight(18, blendShape18);
        
        skinnedMeshRenderer.SetBlendShapeWeight(19, blendShape19);
        
        skinnedMeshRenderer.SetBlendShapeWeight(20, blendShape20);
        
        skinnedMeshRenderer.SetBlendShapeWeight(21, blendShape21);
        
        skinnedMeshRenderer.SetBlendShapeWeight(44, blendShape44);
        
        skinnedMeshRenderer.SetBlendShapeWeight(23, blendShape23);
        
        skinnedMeshRenderer.SetBlendShapeWeight(45, blendShape45);
        
        skinnedMeshRenderer.SetBlendShapeWeight(48, blendShape48);
        
        skinnedMeshRenderer.SetBlendShapeWeight(49, blendShape49);
        
        
        skinnedMeshRenderer.SetBlendShapeWeight(28, blendShape28);
        
        skinnedMeshRenderer.SetBlendShapeWeight(29, blendShape29);
        
    }
}
