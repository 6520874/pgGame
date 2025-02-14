﻿/****************************************************
	文件：StateMove.cs
	作者：Plane
	邮箱: 1785275942@qq.com
	日期：2019/03/19 6:42   	
	功能：移动状态
*****************************************************/

public class StateMove : IState {
    public void Enter(EntityBase entity, params object[] args) {
        entity.currentAniState = AniState.Move;
        //PECommon.Log("Enter StateMove.");
    }

    public void Exit(EntityBase entity, params object[] args) {
        //PECommon.Log("Exit StateMove.");
    }

    public void Process(EntityBase entity, params object[] args) {
        entity.SetBlend(Constants.BlendMove);
        //PECommon.Log("Process StateMove.");
    }
}
