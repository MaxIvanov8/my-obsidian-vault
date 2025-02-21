Mp4 cut
`ffmpeg -i Mp4.mp4 -ss 0:00:10 -to 0:00:15 -c:v libx264 -c:a aac Mp4_cut.mp4 -y`

Mp4 cut quick
`ffmpeg -ss 0:00:10 -y -i Mp4.mp4 -t 0:00:10 -c copy Mp4_cut_q.mp4`

Mp4 with watermark
`ffmpeg -y -i Mp4.mp4 -i watermark.tmp -ss 0:00:10 -to 0:00:15 -filter_complex overlay=5:H-h-5 -c:v libx264 -c:a aac Mp4_w.mp4`

Mp4 with two watermark
`ffmpeg -y -i Mp4_cut1.mp4 -i 1.tmp -i 2.tmp -ss 0:00:01 -to 0:00:03 -filter_complex [1]lut=a=val*0.6[a];[0][a]overlay=5:5[b];[b][2]overlay=5:5 -c:v libx264 -c:a aac opacity.mp4`

`ffmpeg -y -i Mp4_cut1.mp4 -i 1.tmp -ss 0:00:01 -to 0:00:03 -vf drawtext=text='Opentext':x=5:5:fontsize=24:fontcolor=black -c:v libx264 -c:a aac TextOutput.mp4`

Avi cut
`ffmpeg -i Avi.avi -ss 0:00:10 -to 0:00:15 -c:v libx264 -c:a aac Avi_cut.avi -y`

Avi cut quick
`ffmpeg -ss 0:00:10 -y -i Avi.avi -t 0:00:05 -c copy Avi_cut_q.avi`

Avi with watermark
`ffmpeg -y -i Avi.avi -i watermark.tmp -ss 0:00:10 -to 0:00:15 -filter_complex overlay=5:H-h-5 -c:v libx264 -c:a aac Avi_w.avi`

Mkv cut
`ffmpeg -i Mkv.Mkv -ss 0:00:10 -to 0:00:15 -c:v libx264 -c:a aac Mkv_cut.Mkv -y`

Mkv cut quick
`ffmpeg -ss 0:00:10 -y -i Mkv.Mkv -t 0:00:05 -c copy Mkv_cut_q.Mkv`

Mkv with watermark
`ffmpeg -y -i Mkv.Mkv -i watermark.tmp -ss 0:00:10 -to 0:00:15 -filter_complex overlay=5:H-h-5 -c:v libx264 -c:a aac Mkv_w.Mkv`