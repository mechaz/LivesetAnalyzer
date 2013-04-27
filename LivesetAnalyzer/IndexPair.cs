using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LivesetAnalyzer
{
    public class IndexPair
    {
        private int indexRow;
        private int indexColumn;
        private int startIndex;
        private int endIndex;


        public IndexPair(int row, int column, int startIndex, int endIndex)
        {
            this.indexRow = row;
            this.indexColumn = column;
            this.startIndex = startIndex;
            this.endIndex = endIndex;
        }

        public int getRow()
        {
            return indexRow;
        }
        public int getColumn()
        {
            return indexColumn;
        }

        public int getStartIndex()
        {
            return startIndex;
        }

        public int getEndIndex()
        {
            return endIndex;
        }


        public void print() {
		//System.out.println("row: " + getRow());
		//System.out.println("column: " + getColumn());
	}
    }
}
