using LEditor.Models;
using System;
using System.Globalization;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace LEditor.Common.Draggables
{
    /// </summary>
    public class DraggableAdorner : Adorner
    {
        //////////////////////////////////////////////////////////////////////////////////////////////////// Field
        ////////////////////////////////////////////////////////////////////////////////////////// Public

        #region Field

        /// <summary>
        /// 중심 포인트 오프셋
        /// </summary>
        public Point CenterPointOffset;

        /// <summary>
        /// 드레그된 플레이어
        /// </summary>
        public Player DragObject;

        #endregion

        ////////////////////////////////////////////////////////////////////////////////////////// Private

        #region Field

        /// <summary>
        /// 렌더 사각형
        /// </summary>
        private Rect renderRectangle;

        /// <summary>
        /// 렌더 브러시
        /// </summary>
        private Brush renderBrush;

        #endregion

        //////////////////////////////////////////////////////////////////////////////////////////////////// Constructor
        ////////////////////////////////////////////////////////////////////////////////////////// Public

        #region 생성자 - DraggableAdorner(draggable)

        /// <summary>
        /// 생성자
        /// </summary>
        /// <param name="draggable">드래그 가능 객체</param>
        public DraggableAdorner(UIElement _draggable) : base(_draggable)
        {
            Draggable draggable = _draggable as Draggable;

            this.renderRectangle = new Rect(new Size(250, 60));
            
            IsHitTestVisible = false;

            draggable.Background = Brushes.Gray;
            this.renderBrush = draggable.Background.Clone();

            if (draggable.DragPropertyobject != null && draggable.DragPropertyobject is Player player)
                DragObject = player;
            CenterPointOffset = new Point(-this.renderRectangle.Width / 2, -this.renderRectangle.Height / 2);
        }

        #endregion

        //////////////////////////////////////////////////////////////////////////////////////////////////// Method
        ////////////////////////////////////////////////////////////////////////////////////////// Protected

        #region 렌더링 처리하기 - OnRender(drawingContext)

        /// <summary>
        /// 렌더링 처리하기
        /// </summary>
        /// <param name="drawingContext">그리기 컨텍스트</param>
        protected override void OnRender(DrawingContext drawingContext)
        {
            drawingContext.DrawRectangle(this.renderBrush, new Pen(Brushes.Gray, 1), this.renderRectangle);

            ImageSource imageSource = new BitmapImage(DragObject.ImageUri);
            Rect imageRect = new Rect(new Point(0, 0), new Point(renderRectangle.Height, renderRectangle.Height));

            drawingContext.DrawImage(imageSource, imageRect);

            string ToolTipMessage = $"{DragObject.Name}\nRank : {DragObject.Rank} \nMMR : {DragObject.MMR}";
            FormattedText formattedText = new FormattedText(
                                            ToolTipMessage,
                                            CultureInfo.CurrentUICulture,
                                            FlowDirection.LeftToRight,
                                            new Typeface("Verdana"),
                                            this.renderRectangle.Height / 4,
                                            Brushes.Black);
            drawingContext.DrawText(formattedText, new Point(imageRect.Width + 10, 5));

        }
        #endregion
    }
}
