// -----------------------------------------------------------------------------------------------------------
//   <copyright file="BlockMatch.cs" company="Aspose Pty Ltd" author="Stanislav Popov" date="29.08.2024 11:41">
//      Copyright (c) 2001-2024 Aspose Pty Ltd. All rights reserved.
//  </copyright>
// -----------------------------------------------------------------------------------------------------------

namespace Aspose.Imaging.AForge.Adapter.ImageMatch
{
    /// <summary>
    ///     The block match
    /// </summary>
    public class BlockMatch
    {
        #region Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="BlockMatch" /> class.
        /// </summary>
        /// <param name="source">The source.</param>
        internal BlockMatch(Openize.AForge.Imaging.NetStandard.BlockMatch source)
        {
            this.SourcePoint = new Point(source.SourcePoint.X, source.SourcePoint.Y);
            this.MatchPoint = new Point(source.MatchPoint.X, source.MatchPoint.Y);
            this.Similarity = source.Similarity;
        }

        #endregion

        #region Properties

        /// <summary>
        ///     Gets the source point.
        /// </summary>
        /// <value>
        ///     The source point.
        /// </value>
        public Point SourcePoint { get; }

        /// <summary>
        ///     Gets the match point.
        /// </summary>
        /// <value>
        ///     The match point.
        /// </value>
        public Point MatchPoint { get; }

        /// <summary>
        ///     Gets the similarity.
        /// </summary>
        /// <value>
        ///     The similarity.
        /// </value>
        public float Similarity { get; }

        #endregion
    }
}