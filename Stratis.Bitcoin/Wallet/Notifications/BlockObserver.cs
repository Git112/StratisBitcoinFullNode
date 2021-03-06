﻿using NBitcoin;
using Stratis.Bitcoin;

namespace Stratis.Bitcoin.Wallet.Notifications
{
    /// <summary>
    /// Observer that receives notifications about the arrival of new <see cref="Block"/>s.
    /// </summary>
	public class BlockObserver : SignalObserver<Block>
    {
        private readonly ConcurrentChain chain;
        private readonly IWalletSyncManager walletSyncManager;

        public BlockObserver(ConcurrentChain chain, IWalletSyncManager walletSyncManager)
        {
            this.chain = chain;
            this.walletSyncManager = walletSyncManager;
        }

        /// <summary>
        /// Manages what happens when a new block is received.
        /// </summary>
        /// <param name="block">The new block</param>
        protected override void OnNextCore(Block block)
        {            
            this.walletSyncManager.ProcessBlock(block);
        }
    }
}
