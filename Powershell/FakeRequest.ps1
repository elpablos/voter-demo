$resultList = $true, $false, $null

$data = @{
    UID = [Guid]::NewGuid()
    Result = $resultList[(Get-Random -Maximum ([array]$resultList).Count)]
}

#$data = "{ ""Uid"": ""195A39D5-5ADA-4BE3-819F-B5AC76B22DCD"", ""Result"": ""true"" }"
#$data.Length
Invoke-WebRequest -Uri "http://voter.lorenzo.cz/api/vote/create/" -Body $data -Method Post | Out-Null
#Invoke-WebRequest -Uri "http://localhost:58921/api/vote/create/" -Body $data -Method Post | Out-Null

$data