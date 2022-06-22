<template>
    <div>
          <el-table
    :data="tableData"
    style="width: 100%;margin-bottom: 20px;"
    row-key="menuId"
    border
    default-expand-all
    :tree-props="{children: 'children', hasChildren: 'hasChildren'}">
    <el-table-column
      prop="menuId"
      label="编号"
      sortable
      width="180">
    </el-table-column>
    <el-table-column
      prop="menuName"
      label="菜单名称"
      sortable
      width="180">
    </el-table-column>
       <el-table-column
      label="操作"
      width="180">
      <template slot-scope="scope">
      <el-button @click="del(scope.row)">删除</el-button>
      <el-button @click="upd(scope.row)">修改</el-button>
      </template>
    </el-table-column>
 
  </el-table>
  <el-dialog
  title="修改"
  :visible.sync="dialogVisible"
  width="30%"
  :before-close="handleClose">
  <edit-view :EditData="EditData" @edit="edit"></edit-view>
  </el-dialog>
    </div>
</template>

<script>
import EditView from '../views/EditView.vue'
export default {
  components: { EditView },
data()
{
    return {
        dialogVisible:false,
        tableData:[],
        EditData:[]
    }
}   
    ,methods:{
      handleClose(){
        this.dialogVisible=false;
      },
        showInfor()
        {
            this.$axios.get("https://localhost:44349/api/MenuManger/getAll").then
            (
                res=>{
                    this.tableData=res.data;
                    console.log(this.tableData)
                }
                
            )
        },
        del(val)
        {
          if(confirm('是否确认删除'))
          {
            this.$axios.get("https://localhost:44349/api/MenuManger/Del?id="+val.menuId).then
            (
                res=>{
                   if(res.data)
                   {
                    this.$message.success('删除成功');
                    this.showInfor();
                   }
                   else
                   {
                    this.$message.warning('删除失败');
                    this.showInfor();
                   }
         
                }
                
            )
          }
             
        },
        upd(val)
        {
          debugger
          this.EditData=val;
          console.log(this.EditData);

          this.dialogVisible=true;
        },
        edit(val)
        {
          console.log(val);
           this.dialogVisible=false;
           this.showInfor();
        }

    },created()
    {
        this.showInfor();
    }
}
</script>