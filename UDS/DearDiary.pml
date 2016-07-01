<Project Name="DearDiary">
  <Property Name="UDT">
    <Table Name="diary_record">
      <Field AllowNull="true" DataType="BigInt" Default="" Indexed="false" Name="uid" />
      <Field AllowNull="true" DataType="Datetime" Default="" Indexed="false" Name="last_update" />
      <Field AllowNull="true" DataType="String" Default="" Indexed="false" Name="content" />
      <Field AllowNull="true" DataType="Number" Default="" Indexed="true" Name="ref_student_id" />
    </Table>
  </Property>
  <Property Name="UDS">
    <Contract Name="dear.diary.student" Enabled="True">
      <Definition>
        <Authentication Extends="sa" />
      </Definition>
      <Package Name="_">
        <Service Enabled="true" Name="PushDiaryRecord">
          <Definition Type="JavaScript">
            <Code>
              <![CDATA[
		var request = getRequest().Request || getRequest();
		var id = getContextProperty('StudentID');
		
		var content = request.Content || '';
		content = content.replace(/'/ig,"''");
		
		executeSql("INSERT INTO $diary_record(ref_student_id, content)VALUES("+id+",'"+content+"')");
		return { status: 'success'};
	]]>
            </Code>
          </Definition>
        </Service>
      </Package>
    </Contract>
  </Property>
</Project>