using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TenTec.Windows.iGridLib;

namespace WindowsFormsApp2
{
  class iGGroupRowCountManager
  {
		iGrid fGrid;

		internal void Attach(iGrid grid)
		{
			fGrid = grid;
			fGrid.AfterContentsGrouped += new EventHandler(fGrid_AfterContentsGrouped);
		}

		void fGrid_AfterContentsGrouped(object sender, EventArgs e)
		{
			if (fGrid.Rows.Count == 0)
				return;

			// The array to store totals by levels;
			// the last row is always a row with normal cells with max available level:
			int maxGroupLevel = fGrid.Rows[fGrid.Rows.Count - 1].Level - 1;
			int[] LevelSum = new int[maxGroupLevel + 1];
			int count = 0;

			for (int iRow = fGrid.Rows.Count - 1; iRow >= 0; iRow--)
			{
				iGRow curRow = fGrid.Rows[iRow];
				switch (curRow.Type)
				{
					case iGRowType.Normal:
						if (curRow.Visible)
							count++;
						break;
					case iGRowType.AutoGroupRow:
						if (curRow.Level == maxGroupLevel)
							for (int i = 0; i <= maxGroupLevel; i++)
								LevelSum[i] += count;
						curRow.RowTextCell.Value += " (Count=" + LevelSum[curRow.Level].ToString() + ")";
						LevelSum[curRow.Level] = 0;
						count = 0;
						break;
				}
			}
		}
	}
}
